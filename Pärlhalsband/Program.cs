﻿// See https://aka.ms/new-console-template for more information

//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs
//Wrong Program.cs


using PearlNecklace;
using var database = new NecklaceDb();

//PopulateDatabase();
//MostExpensiveNecklace();

//Populate database function
void PopulateDatabase()
{
    /*
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
        necklaceList.Add(Necklace.Factory.CreateRandom());
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


    var p = Pearl.Factory.CreateRandomPearl();
    Console.WriteLine("Create a couple of Random pearls");
    Console.WriteLine(Pearl.Factory.CreateRandomPearl());
    Console.WriteLine(Pearl.Factory.CreateRandomPearl());
}
void MostExpensiveNecklace()
{
    var mostExpensiveNecklace = (from necklace in database.Necklaces
                                 orderby necklace.price descending
                                 select new { necklace.NecklaceID, necklace.price }).FirstOrDefault();
    Console.WriteLine($"Necklace Id: {mostExpensiveNecklace.NecklaceID}, Price: {mostExpensiveNecklace.price}");
    */
}
    
