using System.Collections.Generic;

namespace RestAPITest
{
    public class Employees
    {
        public string status{get;set;}
        public List<Data> data{get;set;}
    }

    public class Data
    {
        public string id { get; set; } 
        public string employee_name { get; set; } 
        public string employee_salary { get; set; } 
        public string employee_age { get; set; } 
        public string profile_image { get; set; } 
    }
}