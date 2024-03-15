import pandas as pd
import numpy as np
import requests
from datetime import datetime
from bs4 import BeautifulSoup
import sqlite3

url = 'https://web.archive.org/web/20230902185326/https://en.wikipedia.org/wiki/List_of_countries_by_GDP_%28nominal%29'
table_attribs = ["Country", "GDP_USD_millions"]
db_name = 'World_Economies.db'
table_name = 'Countries_by_GDP'
csv_path = 'Countries_by_GDP.csv'
sql_connection = sqlite3.connect('World_Economies.db')

def extract(url, table_attribs):
    df = pd.DataFrame(columns=table_attribs)
    html_page = requests.get(url).text
    data = BeautifulSoup(html_page, 'html.parser')
    tables = data.find_all('tbody')
    rows = tables[2].find_all('tr')
    for row in rows:
        col = row.find_all('td')
        if len(col) != 0:
            if col[0].find('a') is not None and '—' not in col[2]:
                data_dict = {"Country":col[0].a.contents[0], "GDP_USD_millions": col[2].contents[0]}
                df1 = pd.DataFrame(data_dict, index=[0])
                df = pd.concat([df,df1], ignore_index=True)
    return df

def transfrom(df):
    GDP_list = df["GDP_USD_millions"].tolist()
    GDP_list = [float("".join(x.split(','))) for x in GDP_list]
    GDP_list = [np.round(x/1000,2) for x in GDP_list]
    df["GDP_USD_millions"] = GDP_list
    df = df.rename(columns={"GDP_USD_millions":"GDP_USD_billions"})
    return df

def load_to_csv(df, csv_path):
    df.to_csv(csv_path)

def load_to_db(df, sql_connection, table_name):
    df.to_sql(table_name, sql_connection, if_exists='replace', index=False) 

def run_query(query_statement, sql_connection):
    print(query_statement)
    query_output = pd.read_sql(query_statement, sql_connection)
    print(query_output)

def log_progress(message):
    timestamp_format = '%Y-%h-%d-%H:%M:%S'
    now = datetime.now()
    timestamp = now.strftime(timestamp_format) 
    with open("etl_project_log.txt","a") as f: 
        f.write(timestamp + ' : ' + message + '\n')    


# log_progress('ETL Starting')
# log_progress('Start extract process')
# df = extract(url, table_attribs)
# log_progress('End extract progress')

# log_progress('Start transformation process')
# df = transfrom(df)
# log_progress('End transformation process')

# log_progress('Start load to csv, db process')
# load_to_csv(df, csv_path)
# load_to_db(df, sql_connection, table_name)
# log_progress('End load to csv, db process')

log_progress('Run query1 process')
run_query(f"SELECT *FROM {table_name}", sql_connection)

log_progress('Run query2 process')
run_query(f"SELECT * FROM {table_name} WHERE GDP_USD_billions >= 100", sql_connection)

# log_progress('ETL process End')
