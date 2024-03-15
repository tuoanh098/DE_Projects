import requests
import sqlite3
import pyodbc
import pandas as pd
from bs4 import BeautifulSoup
def Scraping(url):
    df = pd.DataFrame(columns=["Average Rank","Film","Year","Rotten Tomatoes' Top 100","IMDb's Top 250","Empire's Top 100","AFI's Top 100","BFI's Top 100"])
    count = 0
    html_page = requests.get(url).text
    data = BeautifulSoup(html_page, 'html.parser')
    table = data.find_all('tbody')
    rows = table[0].find_all('tr')
    for row in rows:
        if count < 50:
            col = row.find_all('td')
            for i, td_element in enumerate(col):
                a_tags = td_element.find_all('a')
                if a_tags:
                    col[i] = ' '.join(a_tag.get_text(strip=True) for a_tag in a_tags)

            if len(col)!=0:
                data_dict = {"Average Rank": col[0],
                             "Film": col[1] ,
                             "Year":col[2],
                             "Rotten Tomatoes' Top 100": col[3],
                             "IMDb's Top 250": col[4],
                             "Empire's Top 100": col[5],
                             "AFI's Top 100":  col[6],
                             "BFI's Top 100": col[7],
                            }
                df1 = pd.DataFrame(data_dict, index=[0])
                df = pd.concat([df, df1], ignore_index=True)
        else:
            break
        count += 1
    print(df)
    return df

# def Load_DBSQLT3(data):
#     db_name = 'Movie.db'
#     table_name = 'Top_50'
#     conn = sqlite3.connect(db_name)
#     data.to_sql(table_name, conn, if_exists='replace', index=False)
#     conn.close()

# def Load_RDBMS(data):
#     ...


def Load_CSV(data):
    csv_path = 'top_50_films.csv'
    data.to_csv(csv_path)

def main():
    url = 'https://web.archive.org/web/20230902185655/https://en.everybodywiki.com/100_Most_Highly-Ranked_Films'
    data = pd.DataFrame(Scraping(url))
    # Load_CSV(data)
    # Load_RDBMS(data)

if __name__ == "__main__":
    main()