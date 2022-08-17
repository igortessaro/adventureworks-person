# Adventureworks Person API

This project was created to practice software development techniques and also the use of framworks and tools.

### Folder Structure

```console
  ./
  ├── ci  -> configuration files for pipelines
  ├── src -> source code from the application
  ├── tools -> tools to aid development, such as docker compose
  ├── .gitattributes
  ├── .gitignore
  └── README.md
```

## Design Patterns

* Service
* Factory
* Builder
* Singleton
* Repository
* Dependency Injection
* CQRS
* Mediator

## Technologies

| Dependency | Version
| :--- | ---:
| .Net Core | 6.0
| EntityFrameworkCore | 5.0.7
| MediatR | 10.0.1
| Newtonsof | 13.0.1
| Swagger | 6.4.0
| AutoMapper | 10.1.1
| FluentAssertions | 11.2.0
| MSTest | 2.2.3
| NSubstitute | 4.2.2
| Docker | 20.10.8
| Serilog.AspNetCore | 6.0.1
| Serilog.Sinks.Console | 4.0.1
| Serilog.Sinks.Seq | 5.1.1
| AspNetCore.HealthChecks.SqlServer | 5.0.3
| Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore | 5.0.10

## Solution Projects

| Project | Application Layer |
| :--- | :---
| AdventureWorks.Person.Api | API Rest responsible for communicating with external services. |
| AdventureWorks.Person.Domain | layer that contains all business rules of the 'Person' domain. |
| AdventureWorks.Person.Domain.Tests | Unit tests from the domain layer. |
| AdventureWorks.Person.Infrastructure | layer responsible for abstracting all resources that the domain will need to use. |

## Workflow

In this project we will test the workflow using ``git flow`` with the style of [karma](http://karma-runner.github.io/6.3/dev/git-commit-msg.html) commits.

## Dependencies

In this section, all dependencies that the project has for its functioning will be listed.

### SQL Server Database: Adventureworks

Was chosen to use a microsoft example database, adventureworks which can be downloaded from this [link](https://docs.microsoft.com/pt-br/sql/samples/adventureworks-install-configure?view=sql-server-ver15&tabs=ssms).
To facilitate the process, a docker image was created that contains this database: [adventureworks-sqlserver-database](https://hub.docker.com/repository/docker/igortessaro/adventureworks-sqlserver-database)

## Logging

The application has using Serilog and Seq to log, for to view logs access ```http://localhost:5341/``` <br/>
For more informations read:

* [Serilog](https://serilog.net/)
* [Seq](https://datalust.co/)

## Health Check

This application uses [Health Checks](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-5.0) to verify the application's health and dependencies.

* ```http://localhost/health```: for check with dependencies
* ```http://localhost/health/ready```: for the readiness check. The readiness check filters health checks to the health check with the ready tag.
* ```http://localhost/health/live```: for the liveness check. The liveness check filters out the StartupHostedServiceHealthCheck by returning false in the [HealthCheckOptions.Predicate](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.diagnostics.healthchecks.healthcheckoptions.predicate?view=aspnetcore-5.0#Microsoft_AspNetCore_Diagnostics_HealthChecks_HealthCheckOptions_Predicate) (for more information, see [Filter health checks](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-5.0#filter-health-checks))

## Get Started

### Step 1: Clone this repository

```console
git clone https://github.com/igortessaro/adventureworks-person.git
```

### Enable HTTPS Certificate

Execute these commands into PowerShell:

```console
dotnet dev-certs https --clean
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p Pa1153w0rd
dotnet dev-certs https --trust
```

### Step 2: Run application using docker compose

Make sure you are in the `tools/docker` folder to run the command below

```console
docker compose up -d --build
```
