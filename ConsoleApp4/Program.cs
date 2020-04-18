using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace ConsoleApp4
{
    class Program 
    {
        static void Main(string[] args)
        {
            
            string writePath = @"D:\homeWork\index.html";
 
            List<Person> ListOfPerson = new List<Person>();

            StringBuilder stringBuilder = new StringBuilder("<body>");
            stringBuilder.AppendLine();
            //stringBuilder.AppendLine("</body>");
            //Console.WriteLine(stringBuilder);
            createListOfPersons();

            void createListOfPersons() {
                Person person1 = new Person { Name = "Maxim", Email = "maxim@hotmail.com" };
                Person person2 = new Person { Name = "Igor", Email = "igor@hotmail.com" };
                Person person3 = new Person { Name = "Ivan", Email = "ivan@hotmail.com" };
                Person person4 = new Person { Name = "Maxim<script>alert('Name!')</script>", Email = "max@hotmail.com" };
                
                ListOfPerson.Add(person1);
                ListOfPerson.Add(person2);
                ListOfPerson.Add(person3);
                ListOfPerson.Add(person4);


                if (ListOfPerson.Count() != 0) {
                    foreach (Person person in ListOfPerson) {
                        string encodedHtmlName = System.Security.SecurityElement.Escape(person.Name);
                        string encodedHtmlEmail = System.Security.SecurityElement.Escape(person.Email);
                        stringBuilder.AppendLine($" <a href=\"mailto: {encodedHtmlEmail}\">{encodedHtmlName}</a> | ");
                    }

                   
                    stringBuilder.Remove(stringBuilder.Length- 4, 3);                    
                }

                stringBuilder.AppendLine("</body>");
                Console.WriteLine(stringBuilder);
                writePerson();
            }

            void cleanListOfPerson() {
                if (ListOfPerson.FirstOrDefault() != null) {
                    ListOfPerson.Clear();
                }
            }
        

            void writePerson() {
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(stringBuilder);
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            

        }
    }
}
