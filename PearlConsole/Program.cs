using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

using DbCRUDRepos;
using PearlNecklace;


namespace PearlConsole
{
    static class MyLinqExtensions
    {
        public static void Print<T>(this IEnumerable<T> collection)
        {
            collection.ToList().ForEach(item => Console.WriteLine(item));
        }
    }
    class Program
    {
        private static DbContextOptionsBuilder<NecklaceDb> _optionsBuilder;
        static void Main(string[] args)
        {
            if (!BuildOptions())
                return; //Terminate if not build correctly

            //Remove below comment once you have done:
            //add-migration initial-migration
            //update-database

            /*
            SeedDataBase();
            QueryDatabaseAsync().Wait();
            QueryDatabase_Linq();
            QueryDatabase_DataModel_Linq();
            QueryDatabaseCRUDE().Wait();

            Console.WriteLine("\nPress any key to terminate");
            Console.ReadKey();
            */
        }
    }
}