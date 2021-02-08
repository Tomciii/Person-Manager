//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FH WN">
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
    /// The Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main method.
        /// </summary>
        /// <param name="args">Console arguments.</param>
       public static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Start();
        }
    }
}
