//-----------------------------------------------------------------------
// <copyright file="CategoryManager.cs" company="FH WN">
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
    public class CategoryManager
    {
        /// <summary>
        /// The list of categories.
        /// </summary>
        private List<Category> categories;

        /// <summary>
        /// The edit menu instance to display the categories.
        /// </summary>
        private Menu editMenu;

        /// <summary>
        /// Initializes a new instance of the CategoryManager class.
        /// </summary>
        public CategoryManager()
        {
            this.categories = new List<Category>();
            this.editMenu = new Menu(this.CreateCategoryList());
        }

        /// <summary>
        /// Gets or sets the value of categories.
        /// </summary>
        /// <value>The value of categories.</value>
        public List<Category> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }

        /// <summary>
        /// The delete categories method.
        /// </summary>
        public void DeleteCategories()
        {
            if (this.categories.Count == 0)
            {
                return;
            }

            Console.Clear();

            Menu editMenu = new Menu(this.CreateCategoryList());
            ConsoleKey consoleKey;

            do
            {
                editMenu.PrintMenu("Delete Category");
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
                        this.categories.RemoveAt(editMenu.SelectedItem);
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The edit association method.
        /// </summary>
        /// <param name="peopleManager">Takes a people manager as input.</param>
        public void EditAssociation(PeopleManager peopleManager)
        {
            if (peopleManager.PeopleDatabase.Count == 0 || this.categories.Count == 0)
            {
                return;
            }

            Console.Clear();

            Menu editMenu = new Menu(peopleManager.CreatePeopleList());
            ConsoleKey consoleKey;
            do
            {
                Console.Clear();
                Person person;

                editMenu.PrintMenu("Edit Association");
                consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        this.editMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        this.editMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        person = peopleManager.PeopleDatabase.ElementAt(editMenu.SelectedItem);
                        this.ChangeAssociation(person);
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The search dataset method.
        /// </summary>
        /// <param name="peopleManager">Takes a people manager as input.</param>
        public void SearchDataset(PeopleManager peopleManager)
        {
            ConsoleKey key;
            if (this.categories.Count == 0)
            {
                return;
            }

            Console.Clear();
            this.editMenu.PrintMenuName("Search Datasets");
            do 
            {
                string input = this.GetSearchPhrase();
                Console.Clear();

                this.editMenu.PrintMenuName("Search Datasets");

                for (int i = 0; i < this.categories.Count; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < this.categories.ElementAt(i).Associations.Count; j++)
                    {
                        if (this.categories.ElementAt(i).Associations.ElementAt(j).FirstName.ToLower().Contains(input) || this.categories.ElementAt(i).Associations.ElementAt(j).LastName.ToLower().Contains(input) || this.categories.ElementAt(i).Associations.ElementAt(j).Birthdate.ToString().ToLower().Contains(input))
                        {
                            Console.WriteLine("Category: " + this.categories.ElementAt(i).Name);
                            this.categories.ElementAt(i).DisplayDataSet(peopleManager);
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                if (peopleManager.PeopleDatabase.Count == 0)
                {
                    Console.WriteLine("There arent any people in the database.");
                }

                Console.WriteLine("Press Escape to go back or ANY key to continue.");
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The display datasets method.
        /// </summary>
        /// <param name="peopleManager">Takes a people manager as parameter.</param>
        public void DisplayDatasets(PeopleManager peopleManager)
        {
            if (this.categories.Count == 0)
            {
                return;
            }

            do
            {
                Console.Clear();
                this.editMenu.PrintMenuName("Display Datasets");
                try 
                { 
                Console.WriteLine(this.categories.ElementAt(this.editMenu.SelectedItem).Name + ",  " + (this.editMenu.SelectedItem + 1) + "/" + this.categories.Count);
                Console.WriteLine();
                }
                catch
                {
                }

                this.categories.ElementAt(this.editMenu.SelectedItem).DisplayDataSet(peopleManager);

                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.RightArrow:
                        if (this.editMenu.SelectedItem + 1 != this.categories.Count)
                        {
                            this.editMenu.MoveRight();
                        }

                        break;
                    case ConsoleKey.LeftArrow:
                        this.editMenu.MoveLeft();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The edit categories method.
        /// </summary>
        public void EditCategories()
        {
            if (this.categories.Count == 0)
            {
                return;
            }

            Console.Clear();

            Menu editingMenu = new Menu(this.CreateCategoryList());
            ConsoleKey consoleKey;
            do
            {
                editingMenu.PrintMenu("Edit Category");
                consoleKey = Console.ReadKey(true).Key;
               
                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        editingMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        editingMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        this.EditCategory(this.categories, editingMenu);
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            } 
            while (true);
        }

        /// <summary>
        /// The add category method.
        /// </summary>
        public void AddCategory()
        {
            if (this.categories.Count == 10)
            {
                return;
            }

            Console.Clear();
            this.editMenu.PrintMenuName("Add Category");
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter a category name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.WriteLine();

                if (input.Length < 1 || input.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Category name needs to be at least 1 chars and max 10 chars.");
                }

                Console.ForegroundColor = ConsoleColor.White;
            } 
            while (input.Length < 1 || input.Length > 10);

            this.Categories.Add(new Category(input));
        }

        /// <summary>
        /// The change association method.
        /// </summary>
        /// <param name="person">Takes a person as input.</param>
        private void ChangeAssociation(Person person)
        {
            Menu editMenu = new Menu(this.CreateAssociationList(person));
            ConsoleKey consoleKey;

            do
            {
                Console.Clear();
                editMenu.PrintAssociationMenu(person);
                editMenu.PrintMenu();
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
                        if (this.categories.ElementAt(editMenu.SelectedItem).Associations.Contains(person))
                        {
                            this.categories.ElementAt(editMenu.SelectedItem).Associations.Remove(person);
                        }
                        else
                        {
                            this.categories.ElementAt(editMenu.SelectedItem).Associations.Add(person);
                        }

                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            }
            while (true);
        }

        /// <summary>
        /// The create association list method.
        /// </summary>
        /// <param name="person">Takes a person as input.</param>
        /// <returns>Returns a new list of strings.</returns>
        private List<string> CreateAssociationList(Person person)
        {
            List<string> result = new List<string>();
            string association;
            for (int i = 0; i < this.categories.Count; i++)
            {
                if (this.categories.ElementAt(i).Associations.Contains(person))
                {
                    association = "+";
                }
                else
                {
                    association = "-";
                }

                result.Add("   " + association + "    |    " + this.categories.ElementAt(i).Name);
            }

            return result;
        }

        /// <summary>
        /// The get search phrase method.
        /// </summary>
        /// <returns>Returns the search phrase.</returns>
        private string GetSearchPhrase()
        {
            string input;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter your search phrase: ");
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            return input.ToLower();
        }

        /// <summary>
        /// The edit category method.
        /// </summary>
        /// <param name="categories">Takes a list of categories as input.</param>
        /// <param name="menu">Takes a menu as input.</param>
        private void EditCategory(List<Category> categories, Menu menu)
        {
            categories.ElementAt(menu.SelectedItem).Name = this.GetNameInput();
        }

        /// <summary>
        /// The create category list method.
        /// </summary>
        /// <returns>Returns a list of strings.</returns>
        private List<string> CreateCategoryList()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < this.categories.Count; i++)
            {
                result.Add(this.categories.ElementAt(i).ToString());
            }

            return result;
        }

        /// <summary>
        /// The get name input method.
        /// </summary>
        /// <returns>Returns a name.</returns>
        private string GetNameInput()
        {
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter a category name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.WriteLine();

                if (input.Length < 1 || input.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Category name needs to be at least 1 chars and max 10 chars.");
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
            while (input.Length < 1 || input.Length > 10);

            return input;
        }
    }
}
