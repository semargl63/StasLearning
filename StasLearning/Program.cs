using Newtonsoft.Json;
using System;

namespace StasLearning
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Comment
            Console.WriteLine("Enter the filepath...");
            var filepath = Console.ReadLine();

            /*Big
            comment*/
            var fileReader = new FileReader();
            var fileText = fileReader.ReadFile(filepath);

            var list = JsonConvert.DeserializeObject<UsersList>(fileText);

            var dbProvider = new DbProvider();
            foreach (var user in list.Users)
            {
                dbProvider.WriteToBase(user);
            }

            Console.WriteLine("Enter the user id");
            var id = Console.ReadLine();

            var dbUser = dbProvider.ReadFromBase(id);
            if (dbUser != null)
            { 
                Console.WriteLine($"Id: {id}, name: {dbUser.Name}, birth date: {dbUser.BirthDate.ToString("dd.MM.yyyy")}");
            }
            else
            {
                Console.WriteLine($"There is no user with id {id}");
            }

            Console.ReadLine();
        }
    }
}
