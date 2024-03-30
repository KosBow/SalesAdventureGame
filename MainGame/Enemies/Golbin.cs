using SalesAdventure.MainGame.Items;
using SalesAdventure3000.MainGame;
using System;
using System.Xml.Linq;

namespace SalesAdventure.MainGame.Enemies
{
    internal class Goblin : Enemies
    {
        public int Health { get; set; }


        public Goblin(int health, int x, int y) : base("Goblin", x, y)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"The Goblin took {damage} damage!");

        }

        public void Attack(Player player, int attackDamage)
        {
            player.Health -= attackDamage;
            Console.WriteLine($"The Goblin attacked you for {attackDamage} damage!");
        }

        public void SpawnGoblin(Map gameMap, int numberOfGoblins)
        {
            for (int i = 0; i < numberOfGoblins; i++)
            {
                int xSpawn = gameMap.Random.Next(1, gameMap.width - 1);
                int ySpawn = gameMap.Random.Next(1, gameMap.height - 1);

                Goblin goblin = new Goblin(Health, xSpawn, ySpawn);


                while (gameMap.CollisionDetection(goblin.X, goblin.Y) || gameMap.Goblins.Any(existingGoblin => existingGoblin.X == goblin.X && existingGoblin.Y == goblin.Y))
                {
                    xSpawn = gameMap.Random.Next(1, gameMap.width - 1);
                    ySpawn = gameMap.Random.Next(1, gameMap.height - 1);
                    goblin.X = xSpawn;
                    goblin.Y = ySpawn;
                }

                Console.SetCursorPosition(goblin.X, goblin.Y);
                Console.WriteLine("G");
                gameMap.AddEnemy(goblin);
            }
        }



        public Goblin Copy()
        {
            return new Goblin(Health, 0, 0) { X = X, Y = Y };
        }
    }
}
