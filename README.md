# Parpera backend engineering test

This repo contains my implementation of a solution to the Parpera backend engineering test. It consists of a RESTful API with two endpoints for the `Transaction` resource.

## Overview

A `Transaction` has five properties:

```
Id (Integer)
CreatedAt (DateTime)
Description (String)
Amount (Decimal)
Status (Enum[Cancelled, Completed, Pending])
```

The two API endpoints allow for:

- viewing all the `Transaction`s in reverse chronological order (`GET /api/Transaction`), and
- updating a `Transaction`'s `Status` property (`PATCH /api/Transaction/{id}`)

## Project structure

The two main directories are:

- `src`: contains the application source files
- `tests`: contacts the tests for the application (_Note: still to be added_)

## Setup instructions

Install the .NET 6.0 SDK, specifically make sure you have .NET 6.0.1 and ASP.NET Core 6.0.1 installed. While the project may be comptabile with older versions of .NET, this has not been checked.

Once .NET is installed:

- clone the repo to your local computer
- `cd` into the `src` directory
- run `dotnet run` - this will install project dependencies, build the project, seed the database, and run the project

How you access the API endpoints will depend on whether you have set up [local https certificates](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide). If your local https certificates are set up and working, you can access the API via an HTTP client. Or you can install and use the [`httprepl` CLI tool](https://docs.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-6.0).

You can view the raw OpenAPI Specification (OAS) for the API at `https://localhost:<port>/swagger/v1/swagger.json`, or you can view the Swagger UI version of the OAS at `https://localhost:<port>/swagger`.

See [the overview section](#Overview) above for the a few details about the endpoints.

## Caveats and todo
