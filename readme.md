# gRPC ActiveDirectory Mock

> This is a conceptual repo that may or may not pan out. It is certainly a work in progress, so take all of this as experimental.
> 
> See [gRPC on .NET](https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-6.0) to understand how gRPC works in .NET.

* [Overview](#overview)
* [Instructions](#instructions)

## Overview
[Back to Top](#grpc-activedirectory-mock)

Working out how to setup a standalone ASP.NET Core server that internally handles ActiveDirectory pass-through Authentication and exposes an abstract interface via gRPC API.

The ultimate goal is to provide pass-through ActiveDirectory authentication in [Identity.Server](./Identity.Server/) through the [Identity.Core](./Identity.Core) library.

[Identity.Client](./Identity.Client/IdentityClient.cs) can then interface with the gRPC API and be injected as a service into an ASP.NET Core app.

[Middleware](./App.Api/Middleware/) could then be developed to insert the identity information into the `HttpContext` and additional middleware could synchronize identity with the app database.

A [Controller](./App.Api/Controllers/IdentityController.cs) could then inject [IdentityClient](./Identity.Client/Identity.Client.cs) to interact with the avaiable ActiveDirectory functions exposed through the gRPC API.

## Instructions
[Back to Top](#grpc-activedirectory-mock)

Before running any of the examples, ensure the [Identity.Server](./Identity.Server/) project is running.

To test all of the features of the gRPC API, run the [App.Cli](./App.Cli/) project.

To test the ASP.NET Core middleware interface with the gRPC API, run the [App.Api](./App.Api/) project and navigate to https://localhost:7000/swagger

![image](https://user-images.githubusercontent.com/14102723/180584704-c96d8398-d827-40ea-8414-cb8eb41556a7.png)

**GetCurrentUser**  



### Tasks

Each of the three projects have [task configurations](./.vscode/tasks.json) in VS Code:

* `run-identity`
* `run-api`
* `run-cli`

### Debugging

Each of the three projects have [debug profiles](./.vscode/launch.json) in VS Code:

* Identity Server
* API App
* CLI App

![image](https://user-images.githubusercontent.com/14102723/180584623-2d9fd7d5-d2b4-408d-b382-850c4aa332ed.png)


[Back to Top](#grpc-activedirectory-mock)