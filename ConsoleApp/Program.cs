// Create
using System.Text;

string petFish = "puffer fish";


// Concatenation
petFish = "porcupine " + petFish;

// Template Literal
Console.WriteLine($"I AM BUYING {petFish}. YOU CANNOT STOP ME.");

Console.WriteLine(petFish);

// READ
// Console.WriteLine()


// UPDATE
// petFish[0] = "P";

string newPetFish = petFish.Replace("porcupine", "blue dot");

Console.WriteLine(newPetFish);

// DELETE
// String Builder
StringBuilder newCrustacean = new StringBuilder();
newCrustacean.Append("Fiddler crab");
Console.WriteLine(newCrustacean);
newCrustacean.Remove(0, 8);
Console.WriteLine(newCrustacean);