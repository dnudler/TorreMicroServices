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
This can be installed using docker or running as simple API's. 

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

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
