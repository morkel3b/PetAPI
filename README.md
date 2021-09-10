# PetAPI
### Petshop API using petstore.swagger
**Language:** C#  
**Author:** Kelly Green (morkel3b)
**Date:** 10/09/2021  

**Description**: This is a small console application written in C# which uses the /pet/findByStatus endpoint of the [petstore.swagger.io](https://petstore.swagger.io/) API using the ?status=available parameter. It takes the response as a JSON and converts it into a List of Pet objects. The program then extracts the unique pet category names and presents them to the user. Once a category is selected, the program prints all the pets belonging to that category to the user in reverse alphabetical order.

> **Important Note:** The data retrieved from the petstore.swagger API is unreliable as many of the fields contain either the same value, empty strings or null values. The Pets with null values for category have been filtered out. However, due to the nature of the data, the highest concentration of pets belong to the "string" category and most other categories only contain a small number, if not one, pet.

## Instructions

1. Open Visual Studio 2019 and clone the Github repository using **File** >> **Clone or Checkout Code** (repo link: https://github.com/morkel3b/PetAPI.git)
2. Build the solution using **Build** >> **Build Solution** or Ctrl+Shift+B
3. Run the program in Visual Studio using **Ctrl+F5** (or F5 if debugging is desired)
4. The program will present a list of possible categories.  Enter a valid number for the desired category
5. The program will print a list of animals that belong to that category. Press any key to continue
6. To terminate the program, enter 999 as a value for the category selection
