﻿using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ContactManager.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}