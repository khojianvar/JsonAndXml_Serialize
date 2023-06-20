using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace json_and_xml
{
    public class Employee
    {
        public string Name { get; set; }

        public Employee() { }

        public Employee(string name)
        {
            Name = name;
        }   
    }
}
