//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the Menu logic.</summary>
//-----------------------------------------------------------------------
namespace Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Category class.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The name of the category.
        /// </summary>
        private string name;

        /// <summary>
        /// The list of people associated with this category.
        /// </summary>
        private List<Person> associations;

        /// <summary>
        /// Initializes a new instance of the Category class.
        /// </summary>
        /// <param name="category">Takes a string as name input.</param>
        public Category(string category)
            {
            this.name = category;
            this.associations = new List<Person>();
            }

        /// <summary>
        /// Gets or sets the value of associations.
        /// </summary>
        /// <value>The value of associations.</value>
        public List<Person> Associations
        {
            get
            {
                return this.associations;
            }

            set
            {
                this.associations = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of name.
        /// </summary>
        /// <value>The value of name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// The to string method of this class.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return "Category Name: " + this.Name;
        }

        /// <summary>
        /// Displays the Dataset.
        /// </summary>
        /// <param name="manager">Takes the people manager as parameter. Needed for the index.</param>
        public void DisplayDataSet(PeopleManager manager)
        {
            Console.WriteLine("Index\t\t|\tFirst Name\t|\tLast Name\t|\tDate of Birth\t|\tAge");
            Console.WriteLine("____________________________________________________________________________________________________________");
            for (int i = 0; i < this.associations.Count; i++)
            {
                Console.WriteLine(manager.PeopleDatabase.IndexOf(this.associations.ElementAt(i)) + "\t\t|\t" + this.associations.ElementAt(i).FirstName + "\t\t|\t" + this.associations.ElementAt(i).LastName + "\t\t|\t" + this.associations.ElementAt(i).Birthdate.ToString("dd/MM/yyyy") + "\t|\t" + (DateTime.Now.Year - this.associations.ElementAt(i).Birthdate.Year));
            }
        }
    }
}