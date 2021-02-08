//-----------------------------------------------------------------------
// <copyright file="MainMenu.cs" company="FH WN">
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
    public class MainMenu
    {
        /// <summary>
        /// The console key input.
        /// </summary>
        private ConsoleKey input;

        /// <summary>
        /// The list of menu items.
        /// </summary>
        private List<string> mainMenuItems = new List<string> { "Add Person", "Delete Person", "Edit Person", "Add Category", "Delete Category", "Edit Category", "Edit Association", "Display Dataset", "Search in Dataset", "Quit Application" };
        
        /// <summary>
        /// A new menu.
        /// </summary>
        private Menu menu;

        /// <summary>
        /// The people manager.
        /// </summary>
        private PeopleManager peopleManager;

        /// <summary>
        /// The category manager.
        /// </summary>
        private CategoryManager categoryManager;

        /// <summary>
        /// Initializes a new instance of the MainMenu class.
        /// </summary>
        public MainMenu()
        {
            this.menu = new Menu(this.mainMenuItems);
            this.peopleManager = new PeopleManager();
            this.categoryManager = new CategoryManager();
        }

        /// <summary>
        /// The start method.
        /// </summary>
        public void Start()
        {
            do
            {
                this.menu.PrintMenu("Menu");
                this.input = Console.ReadKey(true).Key;
                switch (this.input)
                {
                    case ConsoleKey.UpArrow:
                        this.menu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        this.menu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        this.ExecuteCommand();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
            while (true);
        }

        /// <summary>
        /// The execute command method.
        /// </summary>
        private void ExecuteCommand()
        {
           switch (this.menu.SelectedItem)
            {
                case 0: this.peopleManager.AddPerson();
                    break;
                case 1:
                    this.peopleManager.DeletePerson();
                    break;
                case 2:
                    this.peopleManager.EditPeople();
                    break;
                case 3:
                    this.categoryManager.AddCategory();
                    break;
                case 4:
                    this.categoryManager.DeleteCategories();
                    break;
                case 5:
                    this.categoryManager.EditCategories();
                    break;
                case 6:
                    this.categoryManager.EditAssociation(this.peopleManager);
                    break;
                case 7:
                    this.categoryManager.DisplayDatasets(this.peopleManager);
                    break;
                case 8:
                    this.categoryManager.SearchDataset(this.peopleManager);
                    break;
                case 9: Environment.Exit(0);
                    break;
            }
        }
    }
}