using System;
using System.Collections;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using static System.Console;

namespace PetAPI
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {
            //Setting up the variables for the program
            bool isRunning = true;
            string entered;
            int enteredNum;
            int petCount;
            List<string> categories = new List<string>();

            //retrieving the list of pets from the petstore.swagger API
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = client.GetStreamAsync("https://petstore.swagger.io/v2/pet/findByStatus?status=available");
            var pets = await JsonSerializer.DeserializeAsync<List<Pet>>(await streamTask); 
            
            //extracting the unique pet categories from the pets list
            foreach (var pet in pets)
            {
                if (pet.category != null)
                {
                    if (!categories.Contains(pet.category.name))
                    {
                        categories.Add(pet.category.name);
                    }
                } 
            }
            WriteLine("Total number of Pets: " + pets.Count);
            WriteLine("Number of unique categories: " + categories.Count);
            
            //sorting the list of pets and reversing the order
            List<Pet> sortedPets = pets.OrderBy(p => p.name).ToList();
            sortedPets.Reverse();

            //loop the program until termination code is entered (999)
            while (isRunning)
            {
                petCount = 0;

                //Prints the category options to the console with numbers
                for (int x = 1; x <= categories.Count; x++)
                {
                    Write("{0}. {1, -20}", x, categories[x - 1]);
                    x++;
                    if (x <= categories.Count)
                    {
                        Write("{0}. {1, -20}", x, categories[x - 1]);
                        x++;
                    }
                    if (x <= categories.Count)
                        WriteLine("{0}. {1, -20}", x, categories[x - 1]);
                }

                //prompts user for an input number
                Write("\nPlease enter the number for the category you wish to see (or 999 to exit): ");
                entered = ReadLine();
                WriteLine();

                //Checks if the entered value is an integer
                if (int.TryParse(entered, out enteredNum))
                {
                    //checks if the entered value is the termination value (999)
                    if (enteredNum == 999)
                    {
                        isRunning = false;
                    }
                    //checks if the entered value is between 1 and the number of categories
                    else if (enteredNum > 0 && enteredNum < (categories.Count + 1))
                    {
                        foreach (var pet in sortedPets)
                        {
                            //checks that the pet category is not null (error handling)
                            if (pet.category != null)
                            {
                                //checks that the pet category name matches the value for the selected category
                                if (pet.category.name == categories[enteredNum - 1])
                                {
                                    WriteLine(pet.name);
                                    petCount++;
                                }
                            }
                        }
                        WriteLine("\nTotal number of pets in {0}: {1}", categories[enteredNum - 1], petCount);
                        WriteLine("Press any key to continue.\n");
                        ReadKey();
                    }
                    //else the number was less than 0 or greater than the number of categories
                    else
                        WriteLine(">>>>> Invalid entry, please enter a valid category number.\n");
                }
                //else the entered value was not an integer
                else
                    WriteLine(">>>>> Invalid entry, please enter a number.\n");
            }
            //termination code has been entered
            WriteLine("\nThe progam has been terminated. Press any key to close.");
            ReadKey();
        }
    }
}
