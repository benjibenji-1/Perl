// See https://aka.ms/new-console-template for more information
using PearlNecklace;
using var database = new AddDbContext();

//PopulateDatabase();



var mostExpensiveNecklace = (from necklace in database.Necklaces
          orderby necklace.price descending
          select new { necklace.ID, necklace.price }).FirstOrDefault();
Console.WriteLine($"Necklace Id: {mostExpensiveNecklace.ID}, Price: {mostExpensiveNecklace.price}");

void PopulateDatabase()
{

    //Clear database
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
        necklaceList.Add(new Necklace());
    }


    //Add necklaces
    necklaceList.ForEach(necklace => database.Necklaces.Add(necklace));
    database.SaveChanges();

    //Add pearls
    foreach (Necklace necklace in necklaceList)
    {
        foreach (Pearl pearl in necklace.pearlBag._pearls)
        {
            Console.WriteLine($"Necklace ID: {necklace.ID}");
            Console.WriteLine($"Previous Pearl ID: {pearl.necklaceID}");
            pearl.necklaceID = necklace.ID;
            database.Pearls.Add(pearl);
            Console.WriteLine($"New Pearl ID: {pearl.necklaceID}");
        }
    }
    database.SaveChanges();
}