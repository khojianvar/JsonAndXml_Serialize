using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace json_and_xml
{
    public class Department
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public Department() { }
        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }
    }
}
