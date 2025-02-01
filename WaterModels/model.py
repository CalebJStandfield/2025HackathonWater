import pandas as pd
import pickle

def is_cat_0(x: pd.DataFrame):
    loaded_model = pickle.load(open("WaterModels\\0_100.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(result[0] == 0):
        return False
    
    return True

def is_cat_1(x: pd.DataFrame):
    loaded_model = pickle.load(open("WaterModels\\100_200.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(result[0] == 0):
        return False
    
    return True

def is_cat_2(x: pd.DataFrame):
    loaded_model = pickle.load(open("WaterModels\\200_300.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(result[0] == 0):
        return False
    
    return True

def is_cat_3(x: pd.DataFrame):
    loaded_model = pickle.load(open("WaterModels\\300_plus.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(result[0] == 0):
        return False
    
    return True


def get_risk(x: pd.DataFrame):
    if (is_cat_0(x)):
        return "Little to no Risk"
    if (is_cat_1(x)):
        return "Moderate Risk"
    elif (is_cat_2(x)):
        return "High Risk"
    elif (is_cat_3(x)):
        return "Severe Risk"

