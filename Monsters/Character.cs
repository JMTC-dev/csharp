using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monsters
{
    public class Character(string name, int health, int gold, int damage, int level)
    {
        public string Name { get; set; } = name;
        public int Health { get; set; } = health;
        public int Gold { get; set; } = gold;
        public int Damage { get; set; } = damage;
        public int Level { get; set; } = level;
    }
}