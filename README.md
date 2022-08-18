# BugTracker

[![GitHub Super-Linter](https://github.com/Anastasia-Tre/BugTracker/workflows/Lint%20Code%20Base/badge.svg)](https://github.com/Anastasia-Tre/BugTracker/actions/workflows/linter.yml)
[![Tests](https://github.com/Anastasia-Tre/BugTracker/actions/workflows/test.yml/badge.svg)](https://github.com/Anastasia-Tre/BugTracker/actions/workflows/test.yml)
[![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Anastasia-Tre/BugTracker/blob/master/LICENCE)

## Description
A bug tracking system is an application that lets you keep track of bugs for projects in a database.

This project is a .NET Core implemented Web API for listing Bugs and assigning users to them. It uses Entity Framework Core to communicate with a SQL Server database.

## Technologies
 - C# 
 - .NET
 - ASP.NET Core
 - Entity Framework Core
 - xUnit.net
 - FluentAssertions


## Building and Running - Non docker

1. Change to the api directory (i.e. `bugTracker.Core/bugTracker.WebApi`)

    `cd bugTracker.WebApi`

2. Issue the `dotnet` restore command (this resolves all NuGet packages)

    `dotnet restore`

3. Issue the `dotnet` build command

    `dotnet build`

4. Issue the `dotnet` run command

    `dotnet run`

    This will start the Kestrel webserver, load the `bugTracker.WebApi` application and tell you, via the terminal, what the url to access `bugTracker.WebApi` will be. Usually this will be `http://localhost:5000`, but it may be different based on your system configuration. Heading to `localhost:5000/swagger` should load the swagger API documentation


## Building and Running - docker

1. Ensure that you are in the root directory of the project

2. Run the following command 

    `docker-compose up --build`

The project should be running on port 8000 of yourt local machine. Heading to `localhost:8090/swagger` should load the swagger API documentation


## Contributors
[Anastasiya Trembach](https://github.com/Anastasia-Tre)

## License
Copyright (c) 2022 Anastasiya Trembach. [MIT License](https://github.com/Anastasia-Tre/BugTracker/blob/master/LICENCE)
