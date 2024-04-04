using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class Person
    {
        // کلید
        public int Id { get; set; }
        // نام
        public string FirstName { get; set; }
        // نام خانوادگی
        public string LastName { get; set; }
        // جنسیت
        public bool Gender { get; set; }
    }
}