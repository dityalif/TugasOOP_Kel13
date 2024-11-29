
using System;

namespace GameSimulation
{
    public class CombatSystem
    {
        private Player player;
        private Enemy enemy;

        public CombatSystem(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void StartBattle()
        {
            Console.WriteLine($"A battle starts against {enemy.Type}!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                PlayerTurn();
                if (enemy.Health > 0)
                {
                    EnemyTurn();
                }
            }

            if (player.Health > 0)
            {
                Console.WriteLine("Player wins the battle!");
                player.LevelUp();
            }
            else
            {
                Console.WriteLine("Player has been defeated.");
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Player's turn.");
            Console.WriteLine("Choose an action: 1. Attack 2. Use Item 3. Escape");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    player.AttackEnemy(enemy);
                    break;
                case "2":
                    UsePlayerItem();
                    break;
                case "3":
                    if (AttemptEscape())
                    {
                        Console.WriteLine("Successfully escaped the battle!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to escape. Enemy takes a turn.");
                        EnemyTurn();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Choose again.");
                    PlayerTurn();
                    break;
            }
        }

        private void EnemyTurn()
        {
            Console.WriteLine("Enemy's turn.");
            enemy.Attack(player);
        }

        private void UsePlayerItem()
        {
            Console.WriteLine("Enter item name to use:");
            string itemName = Console.ReadLine();
            player.Inventory.UseItem(itemName, player);
        }

        private bool AttemptEscape()
        {
            Random rnd = new Random();
            return rnd.Next(100) < player.Luck * 10;
        }
    }
}
