# TaskSync - Real-Time Task Management System
TaskSync is a web-based task management system for teams to create, assign, and track tasks with real-time updates using SignalR. It includes user authentication, task management, and basic reporting, built with ASP.NET Core, SQL Server, and a vanilla JavaScript frontend.
## Features

- User Authentication: Register and login with JWT-based authentication.
- Task Management: Create, edit, assign, and track tasks with statuses and due dates.
- Real-Time Updates: Task status updates are pushed to all users via SignalR.
- Reporting: View basic task progress reports.
- Responsive UI: Simple, clean interface for task management.

## Tech Stack

- Backend: C# with ASP.NET Core 6.0, Entity Framework Core, SignalR
- Database: SQL Server
- Frontend: HTML, CSS, JavaScript (vanilla)
- Authentication: JWT
- Real-Time: SignalR WebSockets

## Setup Instructions

Prerequisites:
- .NET 6.0 SDK
- SQL Server
- Node.js (for serving frontend, optional)


## Backend Setup:
1. Clone the repo: git clone <repo-url>
2. Navigate to TaskSync.Web and restore packages: dotnet restore
3. Update appsettings.json with your SQL Server connection string.
4. Run migrations: dotnet ef migrations add InitialCreate and dotnet ef database update
5. Start the backend: dotnet run (runs on http://localhost:5000)


## Frontend Setup:
1. Navigate to TaskSync.Web
2. Serve files using a static server (e.g., npx serve or VS Code Live Server) on http://localhost:3000


## Usage:
- Register a user via the UI, then login.
- Create and manage tasks, with real-time updates visible to all users.




#
