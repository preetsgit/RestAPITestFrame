using NUnit.Framework;
using RestSharp;

namespace RestAPITest
{
    public class Tests : TestBase
    {               
        [Test]
        public void ValidateEmployeeList()
        {
            string employeelistendpoint = "api/v1/employees";
            resources.EmployeeResource.GetAndValidateEmployeeList(employeelistendpoint,9);
        }
    }
}