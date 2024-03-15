import glob 
import pandas as pd 
import xml.etree.ElementTree as ET 
from datetime import datetime 

def extract_from_csv(file_to_process):
    dataframe = pd.read_csv(file_to_process)
    return dataframe

def extract_from_json(file_to_process):
    dataframe = pd.read_json(file_to_process, lines=True)
    return dataframe

def extract_from_xml(file_to_process):
    dataframe = pd.DataFrame(columns=["car_model","year_of_manufacture","price","fuel"])
    tree = ET.parse(file_to_process)
    root = tree.getroot()
    for person in root:
        car_model = person.find("car_model").text
        year_of_manufacture = person.find("year_of_manufacture").text
        price = float(person.find("price").text)
        fuel = person.find("fuel").text
        dataframe = pd.concat([dataframe, pd.DataFrame([{"car_model":car_model, "year_of_manufacture": year_of_manufacture, "price": price, "fuel": fuel}])], ignore_index=True)
    return dataframe

def extract():
    extracted_data = pd.DataFrame(columns=["car_model","year_of_manufacture","price","fuel"])

    for csvfile in glob.glob("*.csv"):
        extracted_data = pd.concat([extracted_data, pd.DataFrame(extract_from_csv(csvfile))], ignore_index=True)

    for jsonfile in glob.glob("*.json"):
        extracted_data = pd.concat([extracted_data, pd.DataFrame(extract_from_json(jsonfile))], ignore_index=True)

    for xmlfile in glob.glob("*.xml"):
        extracted_data = pd.concat([extracted_data, pd.DataFrame(extract_from_xml(xmlfile))], ignore_index=True)    
    return extracted_data

def transform(data):
    data['price'] = round(data.price, 2)
    return data

def load_data(target_file, transformed_data): 
    transformed_data.to_csv(target_file) 

def log_progress(message): 
    timestamp_format = '%Y-%h-%d-%H:%M:%S' # Year-Monthname-Day-Hour-Minute-Second 
    now = datetime.now() # get current timestamp 
    timestamp = now.strftime(timestamp_format) 
    with open("log_file","a") as f: 
        f.write(timestamp + ',' + message + '\n') 

def main():
    target_file = "transformed_data.csv" 
    log_progress("ETL Job Started") 
    
    # Log the beginning of the Extraction process 
    log_progress("Extract phase Started") 
    extracted_data = extract() 
    
    # Log the completion of the Extraction process 
    log_progress("Extract phase Ended") 
    
    # Log the beginning of the Transformation process 
    log_progress("Transform phase Started") 
    transformed_data = transform(extracted_data) 
    print("Transformed Data") 
    print(transformed_data) 
    
    # Log the completion of the Transformation process 
    log_progress("Transform phase Ended") 
    
    # Log the beginning of the Loading process 
    log_progress("Load phase Started") 
    load_data(target_file,transformed_data) 
    
    # Log the completion of the Loading process 
    log_progress("Load phase Ended") 
    
    # Log the completion of the ETL process 
    log_progress("ETL Job Ended") 
    
if __name__ == "__main__":
    main()