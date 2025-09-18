
using Amazon.Data;
using Amazon.Domain;
using System.Text.Json;

namespace MigrationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadDefaultEmployeesData();
        }

        private static void LoadDefaultEmployeesData()
        {
            string contentAsString = File.ReadAllText("Data.json");

            var employees = JsonSerializer.Deserialize<List<Employee>>(contentAsString);

            using(var constext = new AmazonContext())
            {
                constext.Employees.AddRange(employees);
                constext.SaveChanges();
            }
        }
    }
}
