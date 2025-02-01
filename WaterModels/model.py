import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.ensemble import GradientBoostingClassifier
from sklearn.model_selection import GridSearchCV
import pickle

x_input = pd.DataFrame({
    "Year": [2000],
    "Month": [1],
    "Rainfall": [2.17],
    "Rainfall_3mo_avg": [2.17],
    "Rainfall_6mo_avg": [2.17],
    "Temperature": [35.1],
    "Temperature_3mo_avg": [35.1],
    "Temperature_6mo_avg": [35.1],
    "GSL Levels": [4202.58],
    "GSL_3mo_avg": [4202.58],
    "GSL_6mo_avg": [4202.58],
    "beaver_soil": [53.26],
    "trial_soil": [75.72],
    "parely_soil": [77.28],
    "hayden_soil": [79.97]
})

def is_cat_0(x: pd.DataFrame):
    loaded_model = pickle.load(open("0_100.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(x[0] == 0):
        return False
    
    return True

def is_cat_1(x: pd.DataFrame):
    loaded_model = pickle.load(open("100_200.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(x[0] == 0):
        return False
    
    return True

def is_cat_1(x: pd.DataFrame):
    loaded_model = pickle.load(open("100_200.pkl", 'rb'))
    result = loaded_model.predict(x)

    if(x[0] == 0):
        return False
    
    return True


