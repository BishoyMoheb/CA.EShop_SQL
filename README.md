It is a .NET 5 Minimal API application that have 2 Endpoints and each uses CarterModule & RouteMetaData.

It doesn't need .NET Core API Controllers as the Endpoints do all the functionality that the Controllers do.

It is a CRUD REST API With Clean Architecture & Domain Driven Design In .NET 5. It can be seen as a conversation or downgrading of .NET 7 to a .NET 5. For example, in .NET 7, Endpoints inherit from ICarterModule interface that have MapPost, MapGet, MapPut, MapDelete methods while in .NET 5 Endpoints inherit from CarterModule class that have Post<T>, Get<T>, Put<T>, Delete<T> methods, where T are multiple classes that each inherits from RouteMetaData class.

It uses PostgreSQL for data migration and for all the CRUD REST API operations.
