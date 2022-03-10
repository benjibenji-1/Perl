// See https://aka.ms/new-console-template for more information
using PearlNecklace;


using var database = new AddDbContext();


var neckklaceList = new List<Necklace>();
foreach (var item in database.Necklaces)
{
    database.Necklaces.Remove(item);
}
foreach (var item in database.Pearls)
{
    database.Pearls.Remove(item);
}
for (int i = 0; i < 10; i++)
{
    neckklaceList.Add(new Necklace());
}

neckklaceList.ForEach(necklace => database.Necklaces.Add(necklace));
foreach (Necklace necklace in neckklaceList)
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

Console.WriteLine("Necklace ID S:");
Console.WriteLine($"{neckklaceList[3].ID} {neckklaceList[4].ID}");
Console.WriteLine("Necklace ID end");
