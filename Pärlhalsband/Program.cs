// See https://aka.ms/new-console-template for more information
using PearlNecklace;


using var database = new AddDbContext();
var necklaceTest = new Necklace();
Console.WriteLine("Necklace full price:");
Console.WriteLine($"{necklaceTest.price} {necklaceTest.ID}");
Console.WriteLine("Necklace full price end");

var neckklaceList = new List<Necklace>();
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
    neckklaceList.Add(new Necklace());
}

neckklaceList.ForEach(necklace => database.Necklaces.Add(necklace));
foreach (var necklace in neckklaceList)
{
    int necklaceID = necklace.ID;
    foreach (var pearl in necklace.pearlBag._pearls)
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

