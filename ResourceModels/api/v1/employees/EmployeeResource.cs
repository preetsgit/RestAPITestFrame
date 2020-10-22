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

        private static Employee Employee{get;set;}
        public void InitializeEndPoint(string endpoint,Method httpMethod)
        {
            RestLogger.Info("Calling {0} for resource {1} using {2} http method",ConstUtil.BaseURI,
                                        endpoint,httpMethod.ToString()); 
            RestClient = new RestClient(ConstUtil.BaseURI);            
            RestRequest = new RestRequest(endpoint,httpMethod);                     
        }

        public void GetEmployeeList()
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

        public void GetAndValidateEmployeeList(string endpoint,int expectedEmployeeCount)
        {
            InitializeEndPoint(endpoint,Method.GET);
            GetEmployeeList();
            Assert.AreEqual(RestResponse.StatusCode,System.Net.HttpStatusCode.OK);
            Assert.AreEqual(expectedEmployeeCount,Employee.data.Count);
        }
    }
    }