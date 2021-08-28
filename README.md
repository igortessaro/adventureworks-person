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
| .Net Core | 5.0
| EntityFrameworkCore | 5.0.7
| MediatR | 9.0.0
| Newtonsof | 13.0.1
| Swagger | 6.1.4
| AutoMapper | 10.1.1
| FluentAssertions | 5.10.3
| MSTest | 2.2.3
| NSubstitute | 4.2.2
| Docker | 20.10.8

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

## Get Started

### Step 1: Clone this repository
```console
$ git clone https://github.com/igortessaro/adventureworks-person.git
```
### Step 2: Run application using docker compose
Make sure you are in the `tools/docker` folder to run the command below
```console
$ docker compose up -d --build
```