var item = "Potion";

// switch (item)
// {
//     case "Weapon":
//         Console.WriteLine("Weapon");
//         break;
//     case "Potion":
//         Console.WriteLine("Potion");
//         break;
//     default:
//         Console.WriteLine("No item provided, adventurer");
//         break;
// } Old

var result = item switch
{
    "Weapon" => "Weapon",
    "Potion" => "Potion",
    _ => "No item provided, adventurer"
};

Console.WriteLine(result);