# CrudApp - AspNet Core 2.2

# Running the application.
- git clone https://github.com/adlerpagliarini/CrudApp.git

# Running with Visual Studio
- Open Crud.App.sln on Visual Studio 2017 15.7+ with .NET Core 2.2.104 SDK installed
- Open Visual Studio Package Manager Console - set Crud.App.Infra.Data as default project and run the following command: update-database
- Set Crud.App.WebSite as Startup Project
- Play F5
- Browser open: https://localhost:44324/

# Running with Command-line interface
- "cd" into the main folder project where is the solution - Crud.App.sln
- Run the following commands:
- dotnet restore
- dotnet build
- dotnet ef database update --project src/Crud.App.Infra.Data
- dotnet run --project src/Crud.App.WebSite
- Browser open: https://localhost:5001/

# Running with tests from Command-line interface
- Unit Tests and Integration Tests "dotnet test" command in the main folder, or separately, accessing their own folders
	cd tests\Crud.App.Tests.Integration
	cd tests\Crud.App.Tests.Unity