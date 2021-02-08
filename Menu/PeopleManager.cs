//-----------------------------------------------------------------------
// <copyright file="PeopleManager.cs" company="FH WN">
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
    /// The PeopleManager class.
    /// </summary>
    public class PeopleManager
    {
        /// <summary>
        /// The list of people.
        /// </summary>
        private List<Person> peopleDatabase = new List<Person>();

        /// <summary>
        /// The menu for the manager.
        /// </summary>
        private Menu editmenu;

        /// <summary>
        /// Initializes a new instance of the PeopleManager class.
        /// </summary>
        public PeopleManager()
        {
            this.editmenu = new Menu(this.CreatePeopleList());
        }

        /// <summary>
        /// Gets or sets people database.
        /// </summary>
        /// <value>The value of people database.</value>
        public List<Person> PeopleDatabase
        {
            get
            {
                return this.peopleDatabase;
            }

            set
            {
                this.peopleDatabase = value;
            }
        }

        /// <summary>
        /// The delete person function.
        /// </summary>
        public void DeletePerson()
        {
            if (this.peopleDatabase.Count == 0)
            {
                return;
            }

            Console.Clear();
            Menu editMenu = new Menu(this.CreatePeopleList());
            ConsoleKey consoleKey;
            do
            {
                editMenu.PrintMenu("Delete Person");
                consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        editMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        editMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        this.peopleDatabase.RemoveAt(editMenu.SelectedItem);
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The edit people function.
        /// </summary>
        public void EditPeople()
        {
            if (this.peopleDatabase.Count == 0)
            {
                return;
            }
            
            Console.Clear();
          
            Menu editMenu = new Menu(this.CreatePeopleList());
            ConsoleKey consoleKey;
            do
            {
                editMenu.PrintMenu("Edit Menu");
                consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        editMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        editMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        this.EditPerson(this.peopleDatabase, editMenu);
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The create people list function.
        /// </summary>
        /// <returns>Returns a list of people for the menu.</returns>
        public List<string> CreatePeopleList()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < this.peopleDatabase.Count; i++)
            {
                result.Add(this.peopleDatabase.ElementAt(i).ToString());
            }

            return result;
        }

        /// <summary>
        /// The add person function.
        /// </summary>
        public void AddPerson()
        {
            Console.Clear();
            this.editmenu.PrintMenuName("Add Person");
            Person person = this.CreatePerson();
            this.peopleDatabase.Add(person);
        }

        /// <summary>
        /// The edit person function.
        /// </summary>
        /// <param name="database">Takes the list of people as input.</param>
        /// <param name="menu">Takes the menu as input.</param>
        private void EditPerson(List<Person> database, Menu menu)
        {
            database.ElementAt(menu.SelectedItem).FirstName = this.GetNameInput("first name");
            database.ElementAt(menu.SelectedItem).LastName = this.GetNameInput("last name");
            database.ElementAt(menu.SelectedItem).Birthdate = this.GetDateTime();
        }

        /// <summary>
        /// The create a person function.
        /// </summary>
        /// <returns>Returns a new person.</returns>
        private Person CreatePerson()
        {
            string firstName = this.GetNameInput("first name");
            string lastName = this.GetNameInput("last name");
            DateTime dob = this.GetDateTime();

            return new Person(firstName, lastName, dob);
        }

        /// <summary>
        /// The Get Date Time function.
        /// </summary>
        /// <returns>Returns a date time.</returns>
        private DateTime GetDateTime()
        {
            DateTime dob;
            string input;
            bool parseSuccess = false;
            do
            {
                Console.Write("Please enter the date of birth: ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                
                parseSuccess = DateTime.TryParse(input, out dob);
                
                if (DateTime.Now < dob)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid input, the specified date of birth is in the future.");
                    Console.WriteLine();
                    parseSuccess = false;
                }
                else if (!parseSuccess)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid input. Please try again.");
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.White;
            } 
            while (!parseSuccess);
            return dob;
        }

        /// <summary>
        /// The get name input function.
        /// </summary>
        /// <param name="name">Takes name as input.</param>
        /// <returns>Returns a string.</returns>
        private string GetNameInput(string name)
        {
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the " + name + ": ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();

                if (input.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid input, the " + name + " must be at least 3 characters long.");
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.White;
            } 
            while (input.Length < 3);
          
            return input;
        }
    }
}
