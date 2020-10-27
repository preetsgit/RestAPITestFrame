namespace RestAPITest
{
    public class EmployeeCreateRequest
    {
        public string name{get;set;}
        public string salary{get;set;}
        public string age{get;set;}

        public EmployeeCreateRequest()
        {
            name = string.Empty;
            salary= string.Empty;
            age=string.Empty;
        }
    }
}