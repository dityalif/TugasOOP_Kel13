
using System;

namespace GameSimulation
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public int Luck { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();
        public int Coins { get; set; }

        public Player(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Level = 1;
            Luck = 1;
            Coins = 50;
        }

        public void AttackEnemy(Enemy enemy)
        {
            Console.WriteLine($"{Name} attacks {enemy.Type} for {Attack} damage.");
            enemy.TakeDamage(Attack);
        }

        public void LevelUp()
        {
            Level++;
            Health += 20;
            Attack += 5;
            Defense += 3;
            Luck += 1;
            Console.WriteLine($"{Name} has leveled up to level {Level}! Health: {Health}, Attack: {Attack}, Defense: {Defense}, Luck: {Luck}");
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{Name}'s Stats - Health: {Health}, Attack: {Attack}, Defense: {Defense}, Level: {Level}, Luck: {Luck}, Coins: {Coins}");
        }
    }
}
