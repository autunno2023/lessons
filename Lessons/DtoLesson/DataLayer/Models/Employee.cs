using ServiceLayer;
using System;

namespace DataLayer.Models
{
    public class Employee : HR
    {
        internal int id;
        internal String firstName;
        internal String lastName;
        internal String email;
        internal String department;
        public int Id { get; set; }
        public string Name { get; set; }
        public County County { get; set; }
        public Jobs Jobs { get; set; }
        public Contacts Contacts { get; set; }

    }
}
