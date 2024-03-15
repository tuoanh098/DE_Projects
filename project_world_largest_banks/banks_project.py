import pandas as pd
import numpy as np
from bs4 import BeautifulSoup
from datetime import datetime
import requests
import sqlite3 

def extract(url, table_attribs):
    df = pd.DataFrame(columns=table_attribs)
    data = BeautifulSoup(requests.get(url).text, 'html.parser')
    table = data.find_all('tbody')
    rows = table[0].find_all('tr')
    for row in rows:
        if row.find('td') is not None:
            col =  row.find_all('td')
            name = col[1].find_all('a')[1]['title']
            market = col[2].contents[0][:-1]
            data_dict = {
                "Name": name,
                "MC_USD_Billion": float(market)
            }
            df1 = pd.DataFrame(data_dict, index=[0])
            df = pd.concat([df, df1], ignore_index=True)
    return df

def transform(df, csv_path):
    dataframe = pd.read_csv(csv_path)
    exchange_rate = dataframe.set_index('Currency').to_dict()['Rate']
    df['MC_EUR_Billion'] = [np.round(x*exchange_rate['EUR'],2) for x in df['MC_USD_Billion']]
    df['MC_GBP_Billion'] = [np.round(x*exchange_rate['GBP'],2) for x in df['MC_USD_Billion']]
    df['MC_INR_Billion'] = [np.round(x*exchange_rate['INR'],2) for x in df['MC_USD_Billion']]
    return df

def load_to_csv(df, ouput_file):
    df.to_csv(ouput_file)

def load_to_db(df, table_name, sql_connection):
    df.to_sql(table_name, sql_connection, if_exists='replace',index=False)
    
def run_query(query_statement, sql_connection):
    query_output = pd.read_sql(query_statement, sql_connection)
    print(query_output)

def log_progress(message):
    timestamp_format = '%Y-%h-%d-%H:%M:%S'
    now = datetime.now()
    timestamp = now.strftime(timestamp_format)
    with open('code_log.txt', 'a') as f:
        f.write(f'{timestamp}: {message}\n')


# Initiate
url = 'https://web.archive.org/web/20230908091635%20/https://en.wikipedia.org/wiki/List_of_largest_banks'
database = 'Banks.db'
table_name = 'Largest_banks'
table_attribs = ["Name", "MC_USD_Billion"]
csv_path = "exchange_rate.csv"  
ouput_file = 'Largest_banks_data.csv'
df = pd.DataFrame(columns = table_attribs)
log_progress('Preliminaries complete. Initiating ETL process')

# #Extract data
df = extract(url, table_attribs)
log_progress('Data extraction complete. Initiating Transformation process')
print(df, '\n')

# #Transform data
transform(df, csv_path)
log_progress('Data transformation complete. Initiating Loading process')
print(df, '\n')
print(df['MC_EUR_Billion'][4], '\n')

# #Load to csv
load_to_csv(df, ouput_file)
log_progress('Data saved to CSV file')

#Initiate connection
sql_connection = sqlite3.connect(database)
log_progress('SQL Connection initiated')

# #Load to database
load_to_db(df, table_name, sql_connection)
log_progress('Data loaded to Database as a table, Executing queries')

#Run query 1
query_statement = "SELECT * FROM Largest_banks"
print(query_statement, '\n')
run_query(query_statement, sql_connection)
print()

#Run query 2
query_statement = "SELECT AVG(MC_GBP_Billion) FROM Largest_banks"
print(query_statement, '\n')
run_query(query_statement, sql_connection)
print()

#Run query 3
query_statement = "SELECT Name from Largest_banks LIMIT 5"
print(query_statement, '\n')
run_query(query_statement, sql_connection)
log_progress('Process Complete')
print()

#Close database connection
sql_connection.close()
log_progress('Server Connection closed')
