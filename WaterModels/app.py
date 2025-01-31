from flask import Flask, jsonify, request

app = Flask(__name__)

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

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5001)