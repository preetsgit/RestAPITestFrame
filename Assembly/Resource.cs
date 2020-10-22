using System;

namespace RestAPITest
{
    public class Resources
    {
        public T GetResource<T>()
        {
            dynamic resource = (T)Activator.CreateInstance<T>();
            return resource;
        }

        public EmployeeResource EmployeeResource
        {
            get  
            {
                return GetResource<EmployeeResource>();
            }
        }
    }
}