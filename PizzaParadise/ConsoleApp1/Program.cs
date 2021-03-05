using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PizzaParadise.DAL;

namespace ConsoleApp1
{
    class Program
    {
        static DbContextOptions<PizzaParadiseContext> options;
        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-logs.txt", append: false) { AutoFlush = true };
            string connectionString = File.ReadAllText("C:/revature/Project1cs.txt");
            options = new DbContextOptionsBuilder<PizzaParadiseContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Debug)
                .Options;

            using var context = new PizzaParadiseContext(options);
            List<Inventory> c = context.Inventories
                   .Select(x => x).ToList();

            Console.WriteLine("Current Inventory");
            foreach (Inventory entry in c)
            {
                Console.WriteLine($"{entry.} {entry.ProductId} {entry.Quantity}");
            }
        }
    }
}
