from flask import Flask, jsonify, request

app = Flask(__name__)

IMAGE_FOLDER = "../BlazorProject/wwwroot/images/"

# Example Python function (replace with your actual model code)
def process_data(input_data):
    # Your Python logic here (e.g., water model predictions)
    return {"result": f"Processed: {input_data}"}

@app.route('/process', methods=['POST'])
def process():
    data = request.get_json()  # Get JSON from POST request
    input_data = data.get('input')
    result = process_data(input_data)
    return jsonify(result)

@app.route('/dsci_state_risk', methods=['POST'])
def dsci_state_risk():
    # Get the JSON data from the request
    data = request.get_json()

    # Extract the input values from the request
    rainfall = data['input']
    temp = data['temp']
    state = data['state']

    # Process the data (for example, you could calculate a risk score)
    risk_score = (rainfall + temp) / 2  # Simple example calculation

    # Return the result as a string
    return str(risk_score)

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5001)