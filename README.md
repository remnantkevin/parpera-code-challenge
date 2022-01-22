# Parpera backend engineering test

This repo contains my implementation of a solution to the Parpera backend engineering test. It consists of a RESTful API with two endpoints for the `Transaction` resource.

## Overview

A `Transaction` has five properties:

```csharp
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

- `src/`: contains the application source files
- `tests/`: contains the tests for the application (currently only unit tests for the controller)
  - `UnitTests/Controllers/`

## Setup instructions

Install the .NET 6.0 SDK - specifically make sure you have .NET 6.0.1 and ASP.NET Core 6.0.1 installed. While the project may be compatible with older versions of .NET, this has not been checked. You will also need SQLite to be available on your machine, as it is used to store the `Transaction` data. Also note that this project was developed on MacOS using VSCode; no other editors or OSes have been tested on.

Once .NET is installed:

- clone the repo to your local computer
- `cd` into the `src` directory
- run `dotnet run` - this will install project dependencies, build the project, seed the database, and run the project

How you access the API endpoints will depend on whether you have set up [local https certificates](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide). If your local https certificates are set up and working, you can access the API via an HTTP client. Alternatively, you can install and use the [`httprepl` CLI tool](https://docs.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-6.0).

You can view the raw, auto-generated OpenAPI Specification (OAS) for the API at `https://localhost:<port>/swagger/v1/swagger.json`, or you can view the Swagger UI version of the OAS at `https://localhost:<port>/swagger`.

## Todos and caveats

- Add unit tests for `TransactionRepository`.
- Add integration/functional tests for retrieving all transactions, and updating a transaction.
- Add stricter validations that prevent incorrect values possibly being captured for transaction properties (e.g. integers outside the range of the `TransactionStatus` enum).
- If the requirement is that only the `Status` property should be able to be updated, I would restrict the `Update` endpoint to reflect this.
- I would store `Status` values in the database as strings rather than numbers so that their database values make sense even if application code is incorrectly changed, or if the values need to be shared with other services (internal or external).
- Use integers to represent the transaction amount in cents, and only format cents into something more human-readable when the amount is shown to the user. Using integers instead of decimals would avoid accuracy problems related to floating point calculations.
- Implement authentication and/or authorisation.
- Look into using async processing.
- Use a MySQL or PostgreSQL database instead of SQLite.
