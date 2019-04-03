# CrudApp - AspNet Core 2.2

# Running the application.
- git clone https://github.com/adlerpagliarini/CrudApp.git

# Running with Visual Studio
- Open <b>Crud.App.sln</b> on Visual Studio 2017 15.7+ with .NET Core 2.2.104 SDK installed
- Open Visual Studio Package Manager Console - set <b>Crud.App.Infra.Data</b> as default project and run the following command: update-database
- Set <b>Crud.App.WebSite</b> as Startup Project
- Play F5
- Browser open: https://localhost:44324/

# Running with command-line interface
- "cd" into the main folder project where is the solution - <b>Crud.App.sln</b>
- Run the following commands:
- dotnet restore
- dotnet build
- dotnet ef database update --project <b>src/Crud.App.Infra.Data</b>
- dotnet run --project <b>src/Crud.App.WebSite</b>
- Browser open: https://localhost:5001/

# Running tests from command-line interface
- Unit Tests and Integration Tests "dotnet test" command in the main folder, or separately, accessing their own folders
- cd <b>tests\Crud.App.Tests.Integration</b>
- cd <b>tests\Crud.App.Tests.Unity</b>