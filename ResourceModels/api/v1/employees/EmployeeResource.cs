/// This class represents the Employee object and defines its behaviours and properties

using RestSharp;
using NUnit.Framework;
using System.Net;
using Newtonsoft.Json;
using System;

namespace RestAPITest
{
    public class EmployeeResource
    {
        private static RestClient RestClient{get;set;}
        private static RestRequest RestRequest{get;set;}
        private static IRestResponse RestResponse{get;set;}
        private static Employees Employees{get;set;}
        private static Employee Employee{get;set;}
        private static EmployeeCreateResponse EmployeeCreateResponse{get;set;}
        private static EmployeeUpdateResponse EmployeeUpdateResponse{get;set;}
        private static EmployeeDeleteResponse EmployeeDeleteResponse{get;set;}

        public void InitializeEndPoint(string endpoint,Method httpMethod)
        {
            RestLogger.Info("Calling {0} for resource {1} using {2} http method",ConstUtil.BaseURI,
                                        endpoint,httpMethod.ToString()); 
            RestClient = new RestClient(ConstUtil.BaseURI);            
            RestRequest = new RestRequest(endpoint,httpMethod);                     
        }
        public void InitializeEndPoint(string endpoint,Method httpMethod,string employeeJson)
        {
            RestLogger.Info("Calling {0} for resource {1} using {2} http method",ConstUtil.BaseURI,
                                        endpoint,httpMethod.ToString()); 
            RestClient = new RestClient(ConstUtil.BaseURI);            
            RestRequest = new RestRequest(endpoint,httpMethod);  
            RestRequest.AddParameter(ConstUtil.JSONHeaderParameter, employeeJson, ParameterType.RequestBody);
        }        

        public void GetEmployeeList()
        {           
            try
            {
                RestResponse = RestClient.Execute(RestRequest);
                RestLogger.Info("Response received is : {0}",RestResponse.Content.ToString());
                Employees = JsonConvert.DeserializeObject<Employees>(RestResponse.Content.ToString());
            }
            catch(Exception ex)
            {
                RestLogger.Error(ex.Message);
            }            
        }

        public void GetEmployee()
        {           
            try
            {
                RestResponse = RestClient.Execute(RestRequest);
                RestLogger.Info("Response received is : {0}",RestResponse.Content.ToString());
                Employee = JsonConvert.DeserializeObject<Employee>(RestResponse.Content.ToString());
            }
            catch(Exception ex)
            {
                RestLogger.Error(ex.Message);
            }            
        }

        public void AddEmployee()
        {           
           try
            {
                RestResponse = RestClient.Execute(RestRequest);
                RestLogger.Info("Response received is : {0}",RestResponse.Content.ToString());
                EmployeeCreateResponse = JsonConvert.DeserializeObject<EmployeeCreateResponse>(RestResponse.Content.ToString());
            }
            catch(Exception ex)
            {
                RestLogger.Error(ex.Message);
            }         
        }

        public void DeleteEmployee()
        {           
           try
            {
                RestResponse = RestClient.Execute(RestRequest);
                RestLogger.Info("Response received is : {0}",RestResponse.Content.ToString());
                EmployeeDeleteResponse = JsonConvert.DeserializeObject<EmployeeDeleteResponse>(RestResponse.Content.ToString());
            }
            catch(Exception ex)
            {
                RestLogger.Error(ex.Message);
            }         
        }

        public void GetAndValidateEmployeeList(string endpoint,int expectedEmployeeCount)
        {
            InitializeEndPoint(endpoint,Method.GET);
            GetEmployeeList();
            Assert.AreEqual(RestResponse.StatusCode,System.Net.HttpStatusCode.OK);
            Assert.AreEqual(expectedEmployeeCount,Employees.data.Count);
        }

        public void GetEmployeeAndValidateData(string endpoint,Employee employee)
        {
            InitializeEndPoint(endpoint,Method.GET);
            GetEmployee();
            Assert.AreEqual(RestResponse.StatusCode,System.Net.HttpStatusCode.BadRequest);
            Assert.AreEqual(employee.data.employee_age,Employee.data.employee_age);
            Assert.AreEqual(employee.data.employee_name,Employee.data.employee_name);
            Assert.AreEqual(employee.data.employee_salary,Employee.data.employee_salary);
            Assert.AreEqual(employee.data.id,Employee.data.id);
            Assert.AreEqual(employee.data.profile_image,Employee.data.profile_image);
        }

        public void AddEmployee(string endpoint)
        {
            RestResponse = RestClient.Execute(RestRequest,Method.POST);
        }

        public void AddEmployeeAndValidate(string endpoint,Method httpMethod,string employeeJson,out long empid)
        {
            InitializeEndPoint(endpoint,httpMethod,employeeJson);
            AddEmployee();
            Assert.IsFalse(string.IsNullOrEmpty(EmployeeCreateResponse.data.id.ToString()));
            empid = EmployeeCreateResponse.data.id;
            Assert.AreEqual(RestResponse.StatusCode,System.Net.HttpStatusCode.OK);
            Assert.IsTrue(RestResponse.Content.Contains(ConstUtil.AddSuccessMessage));
        }

        void UpdateEmployee()
        {
            try
            {
                RestResponse = RestClient.Execute(RestRequest);
                RestLogger.Info("Response received is : {0}",RestResponse.Content.ToString());
                EmployeeUpdateResponse = JsonConvert.DeserializeObject<EmployeeUpdateResponse>(RestResponse.Content.ToString());
            }
            catch(Exception ex)
            {
                RestLogger.Error(ex.Message);
            } 
        }

        public void UpdateEmployeeAndValidate(string endpoint,Method httpMethod,string employeeJson)
        {
            InitializeEndPoint(endpoint,httpMethod,employeeJson);
            UpdateEmployee();
            Assert.AreEqual(RestResponse.StatusCode,System.Net.HttpStatusCode.OK);
            Assert.IsTrue(RestResponse.Content.Contains(ConstUtil.UpdateSuccessMessage));
        }

        public void DeleteEmployeeAndValidate(string endpoint,Method httpMethod)
        {
            InitializeEndPoint(endpoint,httpMethod);
            DeleteEmployee();
            Assert.AreEqual(RestResponse.StatusCode,System.Net.HttpStatusCode.OK);
            Assert.IsTrue(RestResponse.Content.Contains(ConstUtil.DeleteSuccessMessage));
        }
    }
    }