//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="FH WN">
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
    /// The Person class.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The first name of a person.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name of a person.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The birthdate of a person.
        /// </summary>
        private DateTime birthdate;

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="firstName">Sets the value for firstName.</param>
        /// <param name="lastName">Sets the value for lastName.</param>
        /// <param name="dateTime">Sets the value for birthdate.</param>
        public Person(string firstName, string lastName, DateTime dateTime)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthdate = dateTime;
        }

        /// <summary>
        /// Gets or sets the value of first name.
        /// </summary>
        /// <value>The value of first name.</value>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of last name.
        /// </summary>
        /// <value>The value of last name.</value>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of birthdate.
        /// </summary>
        /// <value>The value of birthdate.</value>
        public DateTime Birthdate
        {
            get
            {
                return this.birthdate;
            }

            set
            {
                this.birthdate = value;
            }
        }

        /// <summary>
        /// The to string method for the person class.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return "First Name: " + this.FirstName + ", Last Name: " + this.LastName + ", Date of Birth: " + this.Birthdate.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// A to string method but short.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public string ToStringShort()
        {
            return this.FirstName + " " + this.LastName + ", " + this.Birthdate.ToString("dd/MM/yyyy");
        }
    }
}