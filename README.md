# Coffee Grinder Comparison

This project is a web application for comparing coffee grinders. Users can upload images of coffee grinds, and the application will analyze and compare them using Mistral's API.

## Features

- Compare the output of different coffee grinders
- Upload images of coffee grinds for analysis
- Compare with other uploads
- View detailed analysis and feedback

## Architecture

The project consists of:
- **Frontend**: A web interface built with Blazor for uploading images and viewing results.
- **Backend**: A server built with .NET Core to handle image uploads and API requests to Mistral.
- **Mistral API Integration**: For analyzing uploaded images and providing feedback.

## Setup

### Backend (.NET Core)
1. Navigate to the backend directory:
   ```bash
   cd backend/CoffeeGrindBackend
   ```
2. Run the backend:
   ```bash
   dotnet run
   ```
   The backend will start on `http://localhost:5001`.

### Frontend (Blazor)
1. Navigate to the frontend directory:
   ```bash
   cd frontend/CoffeeGrindFrontend
   ```
2. Run the frontend:
   ```bash
   dotnet run
   ```
   The frontend will start on `http://localhost:3001`.
3. Open your browser and navigate to `/upload` to test the image upload feature.

## Usage

1. Upload an image of your coffee grind.
2. The application will analyze the image using Mistral's API.
3. View the analysis and compare it with other uploads.


## Contributing

Contributions are welcome! If you have any suggestions or improvements, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

