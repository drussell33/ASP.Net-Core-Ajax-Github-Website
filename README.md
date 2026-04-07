# ASP.Net Core Ajax GitHub Website

A small ASP.NET Core MVC application that fetches data from the GitHub REST API and renders a personal GitHub profile, repository list, and commit history in the browser. The project uses server-side C# code to call GitHub, shape the responses into application models, and expose lightweight endpoints that the frontend consumes with AJAX. It serves as a straightforward example of MVC, JSON-based API integration, and client-side dynamic updates in .NET Core 3.1.

## Badges

![Repo Size](https://img.shields.io/github/repo-size/drussell33/ASP.Net-Core-Ajax-Github-Website)
![Last Commit](https://img.shields.io/github/last-commit/drussell33/ASP.Net-Core-Ajax-Github-Website)
![Top Language](https://img.shields.io/github/languages/top/drussell33/ASP.Net-Core-Ajax-Github-Website)

## Key Features

- Displays GitHub user profile data for the configured account
- Retrieves and lists repositories for the configured GitHub user
- Loads commit history for a selected repository
- Uses AJAX calls from the browser to update page content without a full refresh
- Exposes MVC routes that return JSON for users, repositories, and commits
- Parses GitHub API responses into dedicated C# model classes
- Uses configuration and user secrets to supply a GitHub API token

## Tech Stack

### Backend
- ASP.NET Core MVC (.NET Core 3.1)
- C#
- Newtonsoft.Json
- `HttpWebRequest` for outbound GitHub API calls

### Frontend
- Razor Views
- JavaScript
- jQuery
- AJAX

### Database
- None

### Tools / Services
- GitHub REST API
- .NET SDK 3.1.403 (`global.json`)
- User Secrets for local secret storage

## Architecture Overview

The application follows a simple ASP.NET Core MVC structure with a thin frontend and controller-driven JSON endpoints.

1. The browser loads the main Razor view at `Home/Index`.
2. Client-side code in `wwwroot/js/main.js` sends AJAX requests to MVC routes such as:
   - `POST /api/users`
   - `POST /api/repos`
   - `GET /api/commits/{user?}/{repo?}` via query parameters
3. `HomeController` receives those requests and creates a `GithubAPI` instance using the current configuration.
4. `GithubAPI` sends authenticated requests to GitHub, parses the JSON payloads, and maps the results into model objects like `User`, `Repo`, and `Commit`.
5. The controller returns those objects as JSON, and the frontend injects the results into the page.

### Visible Patterns
- **MVC** for routing, controllers, and views
- **Model-based response shaping** through `User`, `Repo`, and `Commit`
- **Configuration injection** through `IConfiguration`
- **Logging injection** through `ILogger`
- **Service-style API wrapper** via the `GithubAPI` class

## Project Structure

```tree
ASP.Net-Core-Ajax-Github-Website/
├── .gitignore
├── HW7Solution.sln
├── README.md
└── HW7Project/
    ├── Controllers/
    │   └── HomeController.cs              # MVC controller and JSON endpoints
    ├── Models/
    │   ├── Commit.cs                      # Commit response model
    │   ├── ErrorViewModel.cs              # Standard MVC error model
    │   ├── GithubAPI.cs                   # GitHub API request/parsing logic
    │   ├── Repo.cs                        # Repository response model
    │   └── User.cs                        # User profile response model
    ├── Properties/
    │   └── launchSettings.json            # Local launch profiles
    ├── Views/
    │   ├── Home/
    │   │   ├── Index.cshtml               # Main page
    │   │   └── Privacy.cshtml             # Privacy page
    │   ├── Shared/
    │   │   ├── Error.cshtml               # Error page
    │   │   ├── _Layout.cshtml             # Shared layout
    │   │   └── _ValidationScriptsPartial.cshtml
    │   ├── _ViewImports.cshtml
    │   └── _ViewStart.cshtml
    ├── wwwroot/
    │   ├── css/                           # Static styles
    │   ├── img/                           # Static images
    │   ├── js/
    │   │   ├── main.js                    # AJAX and DOM update logic
    │   │   └── site.js                    # Default site script
    │   ├── lib/                           # Frontend libraries
    │   └── favicon.ico
    ├── appsettings.Development.json
    ├── appsettings.json
    ├── global.json                        # SDK pinning
    ├── HW7Project.csproj                  # Project file and package references
    ├── Program.cs                         # Application entry point
    └── Startup.cs                         # Service registration and route mapping
```

## Getting Started

### Prerequisites

- .NET Core SDK 3.1.403 or a compatible .NET Core 3.1 SDK
- Git
- A GitHub personal access token, because the application sends authenticated requests using `GITAPI:MySecretToken`

### Installation

```bash
git clone https://github.com/drussell33/ASP.Net-Core-Ajax-Github-Website.git
cd ASP.Net-Core-Ajax-Github-Website
```

Restore dependencies:

```bash
dotnet restore HW7Solution.sln
```

Set the required local secret for the GitHub token from the `HW7Project` directory:

```bash
cd HW7Project
dotnet user-secrets set "GITAPI:MySecretToken" "<your-github-token>"
```

### Usage

Run the web application from the project folder:

```bash
dotnet run
```

Or run it from the repository root:

```bash
dotnet run --project HW7Project/HW7Project.csproj
```

Then open the local URL shown by ASP.NET Core in the console output.

### Notes

- The code is currently hardcoded to query the GitHub account `drussell33`.
- The application does not use a database; all displayed data is fetched live from GitHub.
- The route names for repository and commit actions are spelled `GithutReposPage` and `GithutCommitsPage` in the code.

## Roadmap

- [x] Create an ASP.NET Core MVC web application
- [x] Add GitHub API integration for user profile data
- [x] Add GitHub API integration for repository data
- [x] Add GitHub API integration for commit data
- [x] Return JSON from MVC controller actions
- [x] Add client-side AJAX calls for dynamic updates
- [x] Use configuration/user secrets for API authentication
- [ ] Make the target GitHub username configurable from the UI
- [ ] Add robust exception handling around failed API calls
- [ ] Improve the page layout and repository/commit presentation
- [ ] Add loading states and user-facing error messages
- [ ] Add tests for API parsing and controller behavior
- [ ] Refactor `GithubAPI` behind an interface and register it through DI

## Contributing

1. Fork the repository
2. Create a feature branch

   ```bash
   git checkout -b feature/your-change
   ```

3. Commit your work

   ```bash
   git commit -m "Add your change"
   ```

4. Push your branch

   ```bash
   git push origin feature/your-change
   ```

5. Open a Pull Request

## Screenshots / Demo

Screenshots or a demo GIF can be added here to show:

- The GitHub profile section
- The repository listing
- The commit history view after selecting a repository

## Contact

GitHub: [drussell33](https://github.com/drussell33)
