using System.Collections.Generic;

namespace RestAPITest
{
    public class Employee
    {
        public string status{get;set;}
        public EmployeeData data{get;set;}
        public string message{get;set;}

        public Employee()
        {
            status = string.Empty;
            data = new EmployeeData();
            message = string.Empty;
        }
    }

    public class EmployeeData
    {
        public long id { get; set; } 
        public string employee_name { get; set; } 
        public long employee_salary { get; set; } 
        public long employee_age { get; set; } 
        public string profile_image { get; set; } 
    }
}