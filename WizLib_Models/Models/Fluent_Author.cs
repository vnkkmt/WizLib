﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Models.Models
{
    public class Fluent_Author
    {
        public int Author_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Location { get; set; }
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public ICollection<Fluent_BookAuthor> Fluent_BookAuthors { get; set; }

    }
}
