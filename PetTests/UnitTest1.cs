using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetAPI;
using System.Collections.Generic;

namespace PetTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckUniqueCategories()
        {
            //arrange
            List<Pet> pets = new List<Pet>();
            List<string> categories = new List<string>();
            pets.Add(new Pet("dog", "Spot"));
            pets.Add(new Pet("cat", "Scruff"));
            pets.Add(new Pet("bird", "Peter"));
            pets.Add(new Pet("dog", "Spike"));
            pets.Add(new Pet(null, "Jeff"));
            int expected = 3;

            //act
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

            //assert
            Assert.AreEqual(expected, categories.Count);
        }

        [TestMethod]
        public void CheckCategoryPetCount()
        {
            //arrange
            List<Pet> sortedPets = new List<Pet>();
            List<string> categories = new List<string> { "dog", "cat", "bird" };
            sortedPets.Add(new Pet("dog", "Spot"));
            sortedPets.Add(new Pet("cat", "Scruff"));
            sortedPets.Add(new Pet("bird", "Peter"));
            sortedPets.Add(new Pet("dog", "Spike"));
            sortedPets.Add(new Pet(null, "Jeff"));
            int expected = 2;
            int count = 0;
            int enteredNum = 1;

            //act
            foreach (var pet in sortedPets)
            {
                if (pet.category != null)
                {
                    if (pet.category.name == categories[enteredNum - 1])
                    {
                        //WriteLine(pet.name);
                        count++;
                    }
                }
            }

            //assert
            Assert.AreEqual(expected, count);
        }
    }
}
