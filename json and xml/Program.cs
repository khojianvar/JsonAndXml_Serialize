using System;
using System.Net.Security;
using System.Text.Json;
using System.Xml.Serialization;

namespace json_and_xml
{
    public class Program
    {
        static void Main(string[] args)
        {
            Department department = new("Anvar MCHJ");
            Employee employee = new("Quvonch");
            Employee employee1 = new("Zikrillo");
            Employee employee2 = new("MuxammadAli");
            Employee employee3 = new("HumoyunMirzo");

            department.Employees.Add(employee);
            department.Employees.Add(employee1);
            department.Employees.Add(employee2);
            department.Employees.Add(employee3);

            SerializeJson(department);
            SerializeXml(department);
            ReadFileXml(department);
            ReadFileJson(department);
        }
        static void SerializeJson(Department department)
        {
            string path = Directory.GetCurrentDirectory();
            path += "Company.json";

            if (!File.Exists(path))
            {
                File.Create(path).Close();

                using (StreamWriter sw = new StreamWriter(path))
                {
                    string jsonString = JsonSerializer.Serialize(department);
                    sw.WriteLine(jsonString);
                    Console.WriteLine("Object has been serialized (json)");
                }

            }
        }

        static void ReadFileJson(Department department)
        {

            string path = Directory.GetCurrentDirectory();
            path += "Company.xml";

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string alltext = sr.ReadToEnd();

                    var jsonString = JsonSerializer.Deserialize<Department>(alltext);

                    department.Name = jsonString.Name;
                    department.Employees = jsonString.Employees;

                    Console.WriteLine("Successful");

                }
            }
        }

        static void SerializeXml(Department department)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

            string path = Directory.GetCurrentDirectory();
            path += "Company.xml";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, department);

                Console.WriteLine("Object has been serialized");
            }
        }

        static void ReadFileXml(Department department)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                var xml = xmlSerializer.Deserialize(fs) as Department;

                department.Name = xml.Name;
                department.Employees = xml.Employees;

                Console.WriteLine("Success deser*ialize xml");

            }
        }
    }
}