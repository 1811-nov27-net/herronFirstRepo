using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var list = GetPeople();
            var fileName = @"C:\Users\Daniel\Desktop\data.xml";
            var list = DeserilizeFromFile(fileName);
            list[0].Id *= 2;
            SerializeToFile(fileName, list);
        }

        public static void SerializeToFile(string filename, List<Person> people)
        {
            // many formats. Could make up our own, or use JSON, or XML, or something else.
            // use XML here

            // should be generic, but isn't
            var serializer = new XmlSerializer(typeof(List<Person>));
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(filename, FileMode.Create);
                serializer.Serialize(fileStream, people);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Some error in file I/O: {e.Message}");
            }
            finally
            {
                fileStream?.Dispose();
            }
            


        }

        public static List<Person> DeserilizeFromFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            List<Person> result;

            using(var fileStream = new FileStream(fileName, FileMode.Open))
            {
                result = (List<Person>)serializer.Deserialize(fileStream);
            }

            return result;

        }

        static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 20,
                    Name = new Name
                    {
                        FirstName = "Nicholas",
                        MiddleName = "A.",
                        LastName = "Escalona",
                    },
                    Address = new Address
                    {
                        Street = "123 Main St.",
                        City = "Arlington",
                        State = "TX"
                    },
                    Age = 26,
                    Nicknames = { "Nick" }
                },
                new Person
                {
                    Name = new Name
                    {
                        FirstName = "Fred",
                        LastName = "Belotte"
                    }
                }
            };
        }
    }
}
