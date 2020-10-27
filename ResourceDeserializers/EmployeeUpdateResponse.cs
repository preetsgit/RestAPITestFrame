namespace RestAPITest
{
    public class EmployeeUpdateResponse
    {
        public string status{get;set;}
        public EmpUpdatedData data{get;set;}
        public string message{get;set;}

        public EmployeeUpdateResponse()
        {
            status = string.Empty;
            data= new EmpUpdatedData();
            message=string.Empty;
        }
    }

    public class EmpUpdatedData
    {
        public string name{get;set;}
        public string salary{get;set;}
        public string age{get;set;}
    }
}