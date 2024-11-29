
using System;

namespace GameSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 100, 10, 5);
            Game game = new Game(player);
            game.Start();
        }
    }
}
