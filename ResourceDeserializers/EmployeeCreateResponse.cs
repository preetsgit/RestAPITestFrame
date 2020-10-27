namespace RestAPITest
{
    public class EmployeeCreateResponse
    {
        public string status{get;set;}
        public EmpData data{get;set;}
        public string message{get;set;}

        public EmployeeCreateResponse()
        {
            status = string.Empty;
            data= new EmpData();
            message=string.Empty;
        }
    }

    public class EmpData
    {
        public string name{get;set;}
        public string salary{get;set;}
        public string age{get;set;}
        public long id{get;set;}
    }
}