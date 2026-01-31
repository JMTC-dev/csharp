var aquariumStoreInventory = "puffer fish";

if ((aquariumStoreInventory == "puffer fish") || (aquariumStoreInventory == "clown fish"))
{
    Console.WriteLine("I will buy puffer fish or clown!");
}
else
{
    Console.WriteLine("I will not buy anything!");
}

// <>
var fishTankPrice = 1000;

if (fishTankPrice <= 1000)
{
    Console.WriteLine("Buy tank");
}
else
{
    Console.WriteLine("Don't buy");
}

var aquariumFish = "puffer fish";

if (aquariumFish is string)
{
    Console.WriteLine("Aquarium Fish is a string.");
}