using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Z2_Serializacja_Deserializacja
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Person object and set its properties
            Person person = new Person
            {
                Name = "John Smith",
                Age = 30
            };

            // Serialize the Person object to JSON
            string json = JsonConvert.SerializeObject(person);

            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);

            // Deserialize the JSON string to a new Person object
            Person deserializedPerson = JsonConvert.DeserializeObject<Person>(json);

            Console.WriteLine("Deserialized Person:");
            Console.WriteLine("Name: " + deserializedPerson.Name);
            Console.WriteLine("Age: " + deserializedPerson.Age);

            Console.ReadLine();
        }
    }
}