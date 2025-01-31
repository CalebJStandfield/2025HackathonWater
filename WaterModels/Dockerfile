# Use official Python 3.9 image
FROM python:3.9

# Set the working directory inside the container
WORKDIR /app

# Copy all files from your project into the container
COPY . .

# Ensure pip is up to date
RUN pip install --upgrade pip

# Install dependencies from requirements.txt
RUN pip install -r requirements.txt

# Expose the Flask API on port 5000
EXPOSE 5001

# Command to run your API (modify if your main file isn't app.py)
CMD ["python", "app.py"]