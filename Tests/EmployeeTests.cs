using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System;

namespace RestAPITest
{
    public class Tests : TestBase
    {               
        [TestCase]
        public void GetAndValidateEmployeeList()
        {
            string employeelistendpoint = "api/v1/employees";
            resources.EmployeeResource.GetAndValidateEmployeeList(employeelistendpoint,9);
        }

        [TestCase(61,320800,"Tiger Nixon","",1,"1")]
        [TestCase(63,170750,"Garrett Winters","",2,"2")]
        public void GetOneEmployeeAndValidateDetails(long age,long salary,string empname,string profileimage,long id,string empid)
        {
            Employee expectedEmployee = Util.CreateExpectedEmployeeObj(age,salary,empname,id);

            string employeegetendpoint = EndPoint.GetEmployee+empid;
            resources.EmployeeResource.GetEmployeeAndValidateData(employeegetendpoint,expectedEmployee);
        }

        [TestCase("18","18000","TestUser100")]
        [TestCase("30","30000","TestUser200")]
        public void AddOneEmployeeAndValidateDetails(string age,string salary,string empname)
        {   
            long empid;         
            EmployeeCreateRequest empCreateRequest = Util.CreateRequestObj(empname,age,salary);
            string requestbody = JsonConvert.SerializeObject(empCreateRequest);            
            resources.EmployeeResource.AddEmployeeAndValidate(EndPoint.AddEmployee,Method.POST,"",out empid); 
             
            Employee expectedEmployee = Util.CreateExpectedEmployeeObj(age,salary,empname,empid);
            string employeegetendpoint = EndPoint.GetEmployee+empid;  
            resources.EmployeeResource.GetEmployeeAndValidateData(employeegetendpoint,expectedEmployee);
        }    

        [TestCase("181","13000","TestUser1001")]
        public void AddEmployeeThenUpdateAndValidateDetails(string age,string salary,string empname)
        {   
            long empid;         
            EmployeeCreateRequest empCreateRequest = Util.CreateRequestObj(empname,age,salary);
            string requestbody = JsonConvert.SerializeObject(empCreateRequest);            
            resources.EmployeeResource.AddEmployeeAndValidate(EndPoint.AddEmployee,Method.POST,"",out empid); 

            string employeeupdateendpoint = EndPoint.UpdateEmployee+empid;  
            empCreateRequest = Util.CreateRequestObj(empname+"updated",age+10,salary+10);
            requestbody = JsonConvert.SerializeObject(empCreateRequest);   
            resources.EmployeeResource.UpdateEmployeeAndValidate(employeeupdateendpoint,Method.PUT,requestbody);

            Employee expectedEmployee = Util.CreateExpectedEmployeeObj(age,salary,empname,empid);
            string employeegetendpoint = EndPoint.GetEmployee+empid;  
            resources.EmployeeResource.GetEmployeeAndValidateData(employeegetendpoint,expectedEmployee);
        }     

        [TestCase("182","183000","TestUser1002")]
        public void AddEmployeeThenDeleteAndValidateDetails(string age,string salary,string empname)
        {   
            long empid;         
            EmployeeCreateRequest empCreateRequest = Util.CreateRequestObj(empname,age,salary);
            string requestbody = JsonConvert.SerializeObject(empCreateRequest);            
            resources.EmployeeResource.AddEmployeeAndValidate(EndPoint.AddEmployee,Method.POST,"",out empid); 

            string employeeupdateendpoint = EndPoint.DeleteEmployee+empid;  
            resources.EmployeeResource.DeleteEmployeeAndValidate(employeeupdateendpoint,Method.PUT);            
        }           


    }
}