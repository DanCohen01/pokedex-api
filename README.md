# pokedex-api

Pokedex API

How to run:

1) Clone repository
2) Run via IIS express
3) The App is configured to launch the swagger page when started, so you can use the swagger ui, call one of either two endpoints by adding to the url after the port number in a browser or use a tool like postman
	3.1) /pokemon/{pokemon_name} ie: (pokemon/snorlax)
	3.2) /pokemon/translated/{pokemon_name} ie: (pokemon/translated/snorlax)

Considerations:
I have built the project using a clean architecture approach. This is where all dependencies point inwards and the core of the application(business logic) has no dependencies.

Things I would add moving into production:
1) Caching - We could easily add some caching around both pokemon api and the translations api to reduce calls and increase speed.
2) Retry policy - There is a case to be made for something like Polly to be used, for a retry policy, to minimize the errors the end user would see when the third party systems are having any issues.
