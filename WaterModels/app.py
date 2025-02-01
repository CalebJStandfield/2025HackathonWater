from flask import Flask, jsonify, request

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
    temperature = data['']
    gsl_levels = data['temperature']
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

    # Process the data (for example, you could calculate a risk score)
    risk_score = (rainfall + temp) / 2  # Simple example calculation

    # Return the result as a string
    return str(risk_score)

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5001)