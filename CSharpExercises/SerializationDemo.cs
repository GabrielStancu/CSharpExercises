using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace CSharpExercises
{
    class SerializationDemo
    {
        public void Run()
        {
            string xmlText = string.Empty;
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ ID = 1150, FirstName = "Fox", LastName = "Stevenson", Salary = 5000m, Age = 35},
                new Employee{ ID = 1151, FirstName = "Jack", LastName = "Chime", Salary = 2400m, Age = 23},
                new Employee{ ID = 1152, FirstName = "Nathaniel", LastName = "North", Salary = 7600m, Age = 41}
            };

            Serialize(ref xmlText, employees);
            Deserialize(xmlText);           
        }

        private void Serialize(ref string xmlText, List<Employee> employees)
        {
            XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Employee>));
            using (StringWriter sw = new StringWriter())
            {
                xmlWriter.Serialize(sw, employees);
                xmlText = sw.ToString();
                Console.WriteLine(sw.ToString());
            }
        }

        private void Deserialize(string xmlText)
        {
            XmlSerializer xmlReader = new XmlSerializer(typeof(List<Employee>));
            using (StringReader sr = new StringReader(xmlText))
            {
                List<Employee> employees = (List<Employee>)xmlReader.Deserialize(sr);

                foreach(Employee emp in employees)
                {
                    Console.WriteLine($"Id: {emp.ID}, FirstName: {emp.FirstName}, LastName: {emp.LastName}");
                }
            }
        }
    }

    [Serializable()]
    public class Employee
    {
        [XmlAttribute("EmployeeNo")]
        public int ID;
        public string FirstName;
        public string LastName;
        //[XmlIgnoreAttribute]
        public decimal Salary;
        public int Age;
    }
}
