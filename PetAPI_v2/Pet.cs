using System;
using System.Collections.Generic;
using System.Text;

namespace PetAPI
{
    public class Pet
    {
        //public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public Tag[] tags { get; set; }
        public string status { get; set; }

        public Pet (string category, string name)
        {
            if (category != null)
            {
                this.category = new Category(category);
            }            
            this.name = name;
        }

        public Pet ()
        {
        }
    }

    public class Category
    {
        //public long id { get; set; }
        public string name { get; set; }

        public Category (string category)
        {
            this.name = category;
        }

        public Category()
        {
        }
    }

    public class Tag
    {
        //public int id { get; set; }
        public string name { get; set; }
    }
}
