import pandas as pd
from flask import Flask, request

import model

app = Flask(__name__)

IMAGE_FOLDER = "../BlazorProject/wwwroot/images/"

@app.route('/dsci_state_risk', methods=['POST'])
def dsci_state_risk():
    # Get the JSON data from the request
    data = request.get_json()

    # Extract the input values from the request
    year = data['year']
    month = data['month']
    rainfall = data['rainfall']
    temperature = data['temperature']
    gsl_levels = data['gslLevels']
    rainfall_3mo_avg = data['rainfall3MoAvg']
    rainfall_6mo_avg = data['rainfall6MoAvg']
    temperature_3mo_avg = data['temperature3MoAvg']
    temperature_6mo_avg = data['temperature6MoAvg']
    gsl_3mo_avg = data['gsl3MoAvg']
    gsl_6mo_avg = data['gsl6MoAvg']
    beaver_soil = data['beaverSoil']
    trial_soil = data['trialSoil']
    parely_soil = data['parelySoil']
    hayden_soil = data['haydenSoil']

    x = pd.DataFrame({
        "Year" : [year],
        "Month" : [month],
        "Rainfall" : [rainfall],
        "Rainfall_3mo_avg" : [rainfall_3mo_avg],
        "Rainfall_6mo_avg" : [rainfall_6mo_avg],
        "Temperature" : [temperature],
        "Temperature_3mo_avg" : [temperature_3mo_avg],
        "Temperature_6mo_avg" : [temperature_6mo_avg],
        "GSL Levels" : [gsl_levels],
        "GSL_3mo_avg" : [gsl_3mo_avg],
        "GSL_6mo_avg" : [gsl_6mo_avg],
        "beaver_soil" : [beaver_soil],
        "trial_soil" : [trial_soil],
        "parely_soil" : [parely_soil],
        "hayden_soil" : [hayden_soil]
    })

    # Process the data (for example, you could calculate a risk score)
    risk_score =  model.get_risk(x)

    return str(risk_score)


if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5001)