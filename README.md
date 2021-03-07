# pokedex-api

Pokedex API

How to run:

* Clone repository
* Run via IIS express
* The App is configured to launch the swagger page when started, so you can use the swagger ui, call one of either two endpoints by adding to the url after the port number in a browser or use a tool like postman.
	*  /pokemon/{pokemon_name} ie: (pokemon/snorlax)
	*  /pokemon/translated/{pokemon_name} ie: (pokemon/translated/snorlax)

Design:
* I have built the project using a clean architecture approach. This is where all dependencies point inwards and the core of the application(business logic) has no dependencies. 
The API returns sensible HTTP Response codes and a Pokemon object. Where the Pokemon cannot be found, the API will return a 404 with an UnknownPokemon object that makes the application more user friendly.
All business logic is contained in the Application layer, the Infrastrutcure layer contains the calls to the third parties.

Things I would add moving into production:
* Caching - caching could be added around both pokemon api and the translations api to reduce calls and increase speed.
* Retry policy - There is a case to be made for something like Polly to be used, for a retry policy, to minimize the errors the end user would see when the third party systems are having any issues.
