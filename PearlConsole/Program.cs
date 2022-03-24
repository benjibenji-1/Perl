using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

using DbCRUDRepos;
using PearlNecklace; //Project Reference != Project Dependencies up
using DbContextLib;

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
        static void Main()
        {
            if (!BuildOptions())
                return; //Terminate if not build correctly

            //Remove below comment once you have done:
            //add-migration initial-migration
            //update-database

            
            SeedDataBase();
            QueryDatabaseAsync().Wait();
            QueryDatabase_Linq();
            QueryDatabase_DataModel_Linq();
            QueryDatabaseCRUDE().Wait();

            Console.WriteLine("\nPress any key to terminate");
            Console.ReadKey();
            
        }
        private static bool BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<NecklaceDb>();

            #region Ensuring appsettings.json is in the right location
            Console.WriteLine($"DbConnections Directory: {DBConnection.DbConnectionsDirectory}");

            var connectionString = DBConnection.ConfigurationRoot.GetConnectionString("SQLServer_necklaceDB");
            if (!string.IsNullOrEmpty(connectionString))
                Console.WriteLine($"Connection string to Database: {connectionString}");
            else
            {
                Console.WriteLine($"Please copy the 'DbConnections.json' to this location");
                return false;
            }
            #endregion

            _optionsBuilder.UseSqlServer(connectionString);
            return true;
        }

        private static void SeedDataBase()
		{
            var rnd = new Random();
            using var database = new NecklaceDb();
            var necklaceList = new List<Necklace>();
            foreach (var item in database.Necklaces)
            {
                database.Necklaces.Remove(item);
            }
            foreach (var item in database.Pearls)
            {
                database.Pearls.Remove(item);
            }
            for (int i = 0; i < 1000; i++)
            {
                necklaceList.Add(Necklace.Factory.CreateRandom(rnd.Next(5,50)));
            }

            necklaceList.ForEach(necklace => database.Necklaces.Add(necklace));
            foreach (var necklace in necklaceList)
            {
                int necklaceID = necklace.NecklaceID;
                foreach (var pearl in necklace._pearls)
                {
                    pearl.necklaceID = necklaceID;
                    database.Pearls.Add(pearl);
                }
            }
            database.SaveChanges();
        }

        private static async Task QueryDatabaseAsync()
		{
            Console.WriteLine("\n\nQuery Database");
            Console.WriteLine("--------------");
            using (var db = new NecklaceDb(_optionsBuilder.Options))
            {
                var necklCount = await db.Necklaces.CountAsync();
                var pearlCount = await db.Pearls.CountAsync();

                Console.WriteLine($"Nr of Necklaces: {necklCount}");
                Console.WriteLine($"Nr of Pearls: {pearlCount}");

                var n = db.Necklaces.AsEnumerable();
            }
        }

        private static void QueryDatabase_Linq()
		{
            Console.WriteLine("\n\nQuery Database with Linq");
            Console.WriteLine("------------------------");
            using (var db = new NecklaceDb(_optionsBuilder.Options))
            {
                //Use .AsEnumerable() to make sure the Db request is fully translated to be managed by Linq.
                //Use ToList() to ensure the Model is fully loaded
                var necklaces = db.Necklaces.AsEnumerable().ToList();
                var pearls = db.Pearls.AsEnumerable().ToList();

                Console.WriteLine($"Nr of pearls: {pearls.Count()}");
                Console.WriteLine($"Total pearl value: {pearls.Sum(pearl => pearl.Price):C2}");

                Console.WriteLine("\nFirst 5 pearls:");
                pearls.Take(5).OrderByDescending(pearl => pearl.Price).Print();

                Console.WriteLine("Join examples");
                var list1 = necklaces.GroupJoin(necklaces, neck => neck.NecklaceID, pearl => pearl.NecklaceID, (neck, pearl) => new { neck, pearl });
                Console.WriteLine($"\nOuterJoin: Necklace - Pearl via GroupJoin by Necklace, Count: {list1.Count()}");
                //list1.Print();

                var list2 = list1.Where(necklacepearl => necklacepearl.pearl.Count() == 0);
                Console.WriteLine($"\nGroupJoin with Pearl list Count == 0: {list2.Count()}");
                //list2.Print();

                var list3 = list1.Where(necklacepearl => necklacepearl.pearl.Count() != 0);
                Console.WriteLine($"\nGroupJoin with Pearl list Count != 0: {list3.Count()}");
                //list3.Print();

                var list4 = necklaces.Join(pearls, neck => neck.NecklaceID, pearl => pearl.ID, (neck, pearl) => new { neck, pearl });
                Console.WriteLine($"\nInnerJoin Necklace - Pearl via Join, Count: {list4.Count()}");
                //list4.Print();            
            }
        }

        private static void QueryDatabase_DataModel_Linq()
		{
            Console.WriteLine("\n\nQuery Database using fully loaded datamodels");
            Console.WriteLine("------------------------");
            using (var db = new NecklaceDb(_optionsBuilder.Options))
            {
                //Use .AsEnumerable() to make sure the Db request is fully translated to be managed by Linq.
                //Use ToList() to ensure the Model is fully loaded
                var necklaces = db.Necklaces.AsEnumerable().ToList();
                //var pearls = db.Pearls.AsEnumerable().ToList(); ---Not being used, price can be found already in necklace

                var NecklaceMostExpensive = necklaces.OrderByDescending(c => c.price).First();
                Console.WriteLine($"Necklace with highest price:\n {NecklaceMostExpensive}"); //, Price: {NecklaceMostExpensive.price:C2}
            }
        }

        private static async Task QueryDatabaseCRUDE()
		{
            Console.WriteLine("\n\nQuery Database CRUDE");
            Console.WriteLine("--------------------");
            using (var db = new NecklaceDb(_optionsBuilder.Options))
            {
                var _repo = new NecklaceRepository(db);

                Console.WriteLine("Testing ReadAllAsync()");
                var AllNecklaces = await _repo.ReadAllAsync();
                Console.WriteLine($"Nr of Necklaces {AllNecklaces.Count()}");
                Console.WriteLine($"\nFirst 5 Necklaces");
                AllNecklaces.Take(5).Print();


                Console.WriteLine("\nTesting ReadAsync()");
                var LastNecklace1 = AllNecklaces.Last();
                var LastNecklace2 = await _repo.ReadAsync(LastNecklace1.NecklaceID);
                Console.WriteLine($"Last Necklace with pearls.\n{LastNecklace1}");
                Console.WriteLine($"Read Necklace with NecklaceId == Last Necklace\n{LastNecklace2}");
                if (LastNecklace1 == LastNecklace2)
                    Console.WriteLine("Necklaces Equal");
                else
                    Console.WriteLine("ERROR: Necklaces not equal");

                // What to update?
                /*
                Console.WriteLine("\nTesting UpdateAsync()");
                LastNecklace2.price += "_Updated";

                var LastCust3 = await _repo.UpdateAsync(LastNecklace2);
                Console.WriteLine($"Last Customer with updated names.\n{LastNecklace2}");

                if ((LastNecklace2.price == LastCust3.price))
                {
                    Console.WriteLine("Customer Updated");
                    LastCust3.price = LastCust3.price.Replace("_Updated");

                    LastCust3 = await _repo.UpdateAsync(LastCust3);
                    Console.WriteLine($"Last Customer with restored names.\n{LastCust3}");
                }
                else
                    Console.WriteLine("ERROR: Customer not updated");
                */


                Console.WriteLine("\nTesting CreateAsync()");
                var NewNecklace2 = await _repo.CreateAsync(Necklace.Factory.CreateRandom(25));
                var NewNecklace3 = await _repo.ReadAsync(NewNecklace2.NecklaceID);

                Console.WriteLine($"Necklace Inserted in Db.\n{NewNecklace2}");
                Console.WriteLine($"Necklace ReadAsync from Db.\n{NewNecklace3}");

                if (NewNecklace2.NecklaceID == NewNecklace3.NecklaceID)
                    Console.WriteLine("Necklaces Equal");
                else
                    Console.WriteLine("ERROR: Necklaces not equal");


                Console.WriteLine("\nTesting DeleteAsync()");
                var DelNecklace1 = await _repo.DeleteAsync(NewNecklace2.NecklaceID);
                Console.WriteLine($"Necklace to delete.\n{NewNecklace2}");
                Console.WriteLine($"Deleted Necklace.\n{NewNecklace2}");

                if (DelNecklace1 != null && DelNecklace1.NecklaceID == NewNecklace2.NecklaceID)
                    Console.WriteLine("Necklace Equal");
                else
                    Console.WriteLine("ERROR: Necklaces not equal");

                var DelCust2 = await _repo.ReadAsync(DelNecklace1.NecklaceID);
                if (DelCust2 != null)
                    Console.WriteLine("ERROR: Necklace not removed");
                else
                    Console.WriteLine("Necklace confirmed removed from Db");
            }
        }
    }
}