﻿namespace DataLayer.Models
{
    public class JobContract : HR
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public int JobId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Jobs Jobs { get; set; }

    }

}