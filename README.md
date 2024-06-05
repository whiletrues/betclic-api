# betclic-api

W# betclic-api

This is the documentation for the betclic-api project.

## Step 1: Build API

To build the API, follow these steps:

1. Clone the repository.
2. Open the project in your preferred IDE.
3. Build the solution.

## Step 2: Docker Compose

To run the API using Docker Compose, follow these steps:

1. Install Docker on your machine if you haven't already.
2. Open a terminal and navigate to the root directory of the project.
3. Run the following command to start the API:
1. `docker-compose  -f "docker-compose.yml" -f "docker-compose.override.yml" --ansi never up -d`
This will start the API container and any required dependencies.

## Step 3: Swagger UI

Once the API is running, you can access the Swagger UI to explore the endpoints. The default endpoint for Swagger UI is: http://localhost:8080/swagger/index.html
Open this URL in your browser to view the API documentation and test the endpoints.
