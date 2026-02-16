var rand = new Random();


var heroName = "Jack";
var heroHealth = 100;
var heroDamage = 0;

var enemyName = "Goblin";
var enemyHealth = 100;
var enemyDamage = 0;

while (heroHealth > 0 && enemyHealth > 0)
{
    heroDamage = rand.Next(10);
    enemyDamage = rand.Next(10);

    Console.WriteLine(heroName + " is on " + heroHealth);
    Console.WriteLine(enemyName + " is on " + enemyHealth);

    heroHealth -= enemyDamage;
    enemyHealth -= heroDamage;

    if (enemyHealth <= 0)
    {
        Console.WriteLine(enemyName + " has been slain.");
    }
    else if (heroHealth <= 0)
    {
        Console.WriteLine(heroName + " has been slain.");
    }
}
