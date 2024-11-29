using System;
using System.Collections.Generic;

namespace GameSimulation
{
    public class Game
    {
        private Player player;
        private List<Enemy> enemies;
        private Store store;
        private bool isRunning;

        public Game(Player player)
        {
            this.player = player;
            this.enemies = new List<Enemy> { new Deadliner(), new Overloader(), new Procrastinator() };
            this.store = new Store();
            this.isRunning = true;
        }

        public void Start()
        {
            while (isRunning)
            {
                DisplayMenu();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Go to battleground");
            Console.WriteLine("2. View player stats");
            Console.WriteLine("3. Visit store");
            Console.WriteLine("4. Quit game");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartBattle();
                    break;
                case "2":
                    player.DisplayStatus();
                    break;
                case "3":
                    store.DisplayItems();
                    Console.WriteLine("Enter item name to buy:");
                    string itemName = Console.ReadLine();
                    store.BuyItem(itemName, player);
                    break;
                case "4":
                    Console.WriteLine("Exiting game...");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void StartBattle()
        {
            Enemy enemy = enemies[new Random().Next(enemies.Count)];
            CombatSystem combatSystem = new CombatSystem(player, enemy);
            combatSystem.StartBattle();
        }
    }
}
