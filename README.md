# Coffee Grinder Comparison

This project is a web application for comparing coffee grinders. Users can upload images of coffee grinds, and the application will analyze and compare them using Mistral's API.

## Features

- Compare the output of different coffee grinders
- Upload images of coffee grinds for analysis
- Compare with other uploads
- View detailed analysis and feedback from Mistral AI

## Architecture

The project consists of:
- **Frontend**: A modern web interface built with **React** and Vite for uploading images and viewing results.
- **Backend**: A REST API built with **.NET 8 Core** to handle image uploads and API requests to Mistral.
- **Mistral API Integration**: For analyzing uploaded images and providing AI-powered feedback.

### Project Structure

```
coffee_grinder/
├── frontend/               # React frontend
│   ├── public/             # Static files
│   ├── src/                # React source code
│   │   ├── pages/          # Page components
│   │   ├── components/     # Reusable components
│   │   ├── hooks/          # Custom React hooks
│   │   ├── services/       # API service layer
│   │   ├── App.jsx         # Main app component
│   │   └── main.jsx        # Entry point
│   ├── package.json        # Node.js dependencies
│   └── vite.config.js      # Vite configuration
│
├── backend/                # .NET 8 Core backend
│   ├── Controllers/        # API controllers
│   ├── Models/             # Data models
│   ├── Services/           # Business logic services
│   ├── CoffeeGrinderBackend.csproj  # .NET project file
│   └── Program.cs          # Entry point
│
├── README.md               # Project documentation
└── .gitignore              # Git ignore rules
```

## Setup

### Prerequisites

- **.NET 8 SDK** (for backend)
- **Node.js 18+** (for frontend)
- **Mistral API Key** (for AI analysis)

### Backend (.NET 8 Core)

1. Navigate to the backend directory:
   ```bash
   cd backend
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Configure your Mistral API key in `backend/appsettings.json`:
   ```json
   {
     "Mistral": {
       "ApiKey": "YOUR_MISTRAL_API_KEY",
       "ApiUrl": "https://api.mistral.ai/v1"
     }
   }
   ```

4. Run the backend:
   ```bash
   dotnet run
   ```
   The backend will start on `http://localhost:5000` (or `https://localhost:5001`).

### Frontend (React)

1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Run the frontend:
   ```bash
   npm run dev
   ```
   The frontend will start on `http://localhost:3000`.

4. Open your browser and navigate to `http://localhost:3000/upload` to test the image upload feature.

## Usage

1. Navigate to the **Upload** page.
2. Upload an image of your coffee grind.
3. The application will analyze the image using Mistral's API.
4. View the analysis results and compare with other uploads on the **Compare** page.

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/analyze` | Upload and analyze a coffee grind image |
| GET | `/api/analyze/uploads` | Get all uploaded analyses |

## Contributing

Contributions are welcome! If you have any suggestions or improvements, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
