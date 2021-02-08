//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="FH WN">
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
    /// The Menu class.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// The list of menu items.
        /// </summary>
        private List<string> menuItems;

        /// <summary>
        /// The index for the selected item.
        /// </summary>
        private int selectedItem;

        /// <summary>
        /// Initializes a new instance of the Menu class.
        /// </summary>
        /// <param name="menuItems">Sets up the menu items.</param>
        public Menu(List<string> menuItems)
        {
            this.menuItems = menuItems;
        }

        /// <summary>
        /// Gets the value of menu items.
        /// </summary>
        /// <value>The value of menu items.</value>
        public List<string> MenuItems
        {
            get
            {
                return this.menuItems;
            }

            private set
            {
                this.menuItems = value;
            }
        }

        /// <summary>
        /// Gets the value of selected item.
        /// </summary>
        /// <value>The value of selected item.</value>
        public int SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            private set
            {
                this.selectedItem = value;
            }
        }

        /// <summary>
        /// The print menu name method.
        /// </summary>
        /// <param name="menuTitle">Takes a menu name as input.</param>
        public void PrintMenuName(string menuTitle)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------");
            Console.WriteLine(menuTitle);
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// The print association menu method.
        /// </summary>
        /// <param name="person">Takes a person as input.</param>
        public void PrintAssociationMenu(Person person)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Edit Association");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.Write("Person: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(person.ToStringShort());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("State   |  Name");
            Console.WriteLine("____________________________");
        }

        /// <summary>
        /// The move up method.
        /// </summary>
        public void MoveUp()
        {
           if (this.SelectedItem != 0)
            {
                this.SelectedItem--;
            }
        }

        /// <summary>
        /// The move left method.
        /// </summary>
        public void MoveLeft()
        {
            if (this.SelectedItem != 0)
            {
                this.SelectedItem--;
            }
        }

        /// <summary>
        /// The move down method.
        /// </summary>
        public void MoveDown()
        {
            if (this.SelectedItem != this.MenuItems.Count - 1)
            {
                this.SelectedItem++;
            }
            else if (this.SelectedItem == this.MenuItems.Count - 1)
            {
                this.SelectedItem = 0;
            }
        }

        /// <summary>
        /// The move right method.
        /// </summary>
        public void MoveRight()
        {
            if (this.SelectedItem != this.MenuItems.Count - 1)
            {
                this.SelectedItem++;
            }
            else if (this.SelectedItem == this.MenuItems.Count - 1)
            {
                this.SelectedItem = 1;
            }
        }

        /// <summary>
        /// The print menu method.
        /// </summary>
        public void PrintMenu()
        {
            for (int index = 0; index < this.MenuItems.Count; index++)
            {
                if (index == this.SelectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(this.MenuItems.ElementAt(index));
            }
        }

        /// <summary>
        /// The print menu method.
        /// </summary>
        /// <param name="menuName">Takes a string as input.</param>
        public void PrintMenu(string menuName)
        {
            Console.Clear();
            this.PrintMenuName(menuName);

            for (int index = 0; index < this.MenuItems.Count; index++)
            {
                if (index == this.SelectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(this.MenuItems.ElementAt(index));
            }
        }
    }
}
