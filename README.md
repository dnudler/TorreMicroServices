# TorreMicroServices

Diego Nudler Techincal Test 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

.Net core 2.2
SQL Server (any version)
Visual Studio (any version)

### Installing
This can be installed using docker or running as simple API's. Once you cloned this repository follow this steps:

1) Create a Database in your local repository
2) Change the ConnectionString in User.Api in appsettings.json (if you're running it in development mode, appsettings.Development.json)
	2.1) Example: 
		"ConnectionStrings": {
			"TorreDB": "Server=(local);Database=Torre;Trusted_Connection=True;ConnectRetryCount=0"
		}
	2.2) User should have permissions to create table, update, delete, read
3) Change the ConnectionString in Task.Api in appsettings.json (if you're running it in development mode, appsettings.Development.json)
	3.1) Example: 
		"ConnectionStrings": {
			"TorreDB": "Server=(local);Database=Torre;Trusted_Connection=True;ConnectRetryCount=0"
		}
	3.2) User should have permissions to create table, update, delete, read
4) Run User.Api
5) Run Task.Api
6) Run Torre.Web


## Deployment

Add additional notes about how to deploy this on a live system


## Authors

* **Diego Nudler** - *Initial work* - (https://github.com/dnudler)

## Important Architecture Note

This solution needs a API Gateway, I would've used the Microsoft Azure API Management application to do it. 
I don't have the credentials to create it for this solution. 