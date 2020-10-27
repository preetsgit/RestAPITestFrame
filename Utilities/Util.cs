///This is an Utility class which has commonly used utilities across project
using System;

namespace RestAPITest
{
    public class Util
    {
        public static Employee CreateExpectedEmployeeObj(string age,string salary,string empname,long empid)
        {
            Employee expectedEmployee = new Employee();
            expectedEmployee.data.employee_age = Int64.Parse(age);
            expectedEmployee.data.employee_salary = Int64.Parse(salary);
            expectedEmployee.data.employee_name = empname;
            expectedEmployee.data.id = empid;
            expectedEmployee.data.profile_image = "";

            return expectedEmployee;
        }

        public static Employee CreateExpectedEmployeeObj(long age,long salary,string empname,long empid)
        {
            Employee expectedEmployee = new Employee();
            expectedEmployee.data.employee_age = age;
            expectedEmployee.data.employee_salary = salary;
            expectedEmployee.data.employee_name = empname;
            expectedEmployee.data.id = empid;
            expectedEmployee.data.profile_image = "";

            return expectedEmployee;
        }

        public static EmployeeCreateRequest CreateRequestObj(string empName,string age,string salary)
        {
            EmployeeCreateRequest createRequest = new EmployeeCreateRequest();
            createRequest.name = empName;
            createRequest.age=age;
            createRequest.salary = salary;

            return createRequest;   
        }
    }
}