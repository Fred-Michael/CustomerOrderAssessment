# CustomerOrderAssessment

This is an API for a customer-centric application.

It contains CRUD operations and tests written to get, update, edit and delete a customer.

## Download/clone the the source code.
## Run dotnet restore to build the project (this should bring in all non-existing nuget packages for the app)
## launch the app and navigate to the route (as specified in the launchSettings)
## test the endpoints with Postman:
* [HttpGet("get-all-customers")] - getting all customers
* [HttpGet("get-customer-by-id")] - getting a particular customer
* [HttpGet("get-customer-by-name")] - fetching a customer by his/her name
* [HttpPost("add-customer")] - to add a customer
* [HttpPatch("update-customer")] - to update an existing customer
* [HttpDelete("delete-customer")] - to delete a customer

Libraries used:
* - Microsoft.EntityFrameworkCore.Design
* - Microsoft.EntityFrameworkCore.Relational
* - Microsoft.EntityFrameworkCore.Sqlite
* - Microsoft.EntityFrameworkCore.Tools
* - Moq
* - NUnit
* - NUnit3TestAdapter
* - Microsoft.NET.Test.Sdk
