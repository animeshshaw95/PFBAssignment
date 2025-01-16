### Contains-All-Alphabets API Documentation

## Overview

# The Contains-All-Alphabets API checks whether a given string contains all alphabets.
# It returns a boolean indicating the result.

- Project Structure
	- PFBAssignment: The main project
		- Controllers
			- AlphabetCheckerController.cs: Contains the controller class responsible for handling HTTP requests related to alphabet checking.
		- Services
			- AlphabetService.cs: Contains the service class implementing the logic for checking if a string contains all alphabets.
			- IAlphabetService.cs: Defines the interface for the AlphabetService, promoting loose coupling.
		- PFBAssignment Test: Test project
			- AlphabetCheckerControllerTests.cs: Contains unit tests for the AlphabetCheckerController.
			- AlphabetServiceTests.cs: Contains unit tests for the AlphabetService.
			
- Code Structure
	- IAlphabetService Interface:
		Defines a single method: ContainsAllAlphabets(string input) which takes a string as input and returns a boolean indicating whether the string contains all alphabets.
		
	- AlphabetService Class:
		- Implements the IAlphabetService interface.
		
	- AlphabetCheckerController
		- Injects an instance of IAlphabetService through constructor injection
		- Contains the ContainsAllAlphabets action method
			- Validates the input string (cannot be null or empty). Returns BadRequest if validation failed.
			- Calls the ContainsAllAlphabets method of the injected service.
			- Returns Ok with the result
	
	- AlphabetServiceTests Class
		- Contains unit tests for the AlphabetService
			- ContainsAllAlphabets_WithAllAlphabets_ReturnsTrue: Tests with a valid input containing all alphabets.
			- ContainsAllAlphabets_WithoutAllAlphabets_ReturnsFalse: Tests with an input missing some alphabets.
			- ContainsAllAlphabets_WithEmptyInput_ReturnsFalse: Tests with an empty input.
			
	- AlphabetCheckerControllerTests Class
		- Contains unit tests for the AlphabetCheckerController
			- ShouldReturnTrue_WhenInputContainsAllAlphabets: Tests with a valid input and expects an Ok.
			- ShouldReturnFalse_WhenInputDoesNotContainAllAlphabets: Tests with an invalid input (empty or null) and expects a BadRequest.
			- ShouldReturnBadRequest_WhenInputIsNullOrEmpty: Tests with an input missing some alphabets and expects an Ok with a false result.

- Run the API
	- Build the project: Open the solution in Visual Studio and build
	- Run the application: Press F5 to run the application
	- Test the API: Swagger is configured so you can make a request on the following endpoint.
		- http://localhost:5110/api/AlphabetChecker/contains-all-alphabets
		- Request Body: The request body should contain a raw string in JSON format. Example: "abcdefghijklmnopqrstuvwxyz"
		- Response 200: { "containsAllAlphabets": true }
		- Response 400: "Input cannot be null or empty."