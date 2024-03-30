using SalesAdventure.MainGame;
using SalesAdventure.MainGame.Items;
using SalesAdventure3000.MainGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MMORPG.MainGame
{
    internal class HealthPotion : Item
    {
        public int Health { get; set; }
        public int Spawn { get; set; }
        private Map gameMap;
     
        public HealthPotion(int health, int spawns, Map gameMap, int x, int y) : base("Healthpotion", x, y)
        {
            this.Health = health;
            this.Spawn = spawns;
            this.gameMap = gameMap;
        }

        public void SpawnHealthPotion(Map gameMap, int numberOfPotions)
        {
            for (int i = 0; i < numberOfPotions; i++)
            {
                int xSpawn = gameMap.Random.Next(1, gameMap.width - 1);
                int ySpawn = gameMap.Random.Next(1, gameMap.height - 1);

                HealthPotion potion = new HealthPotion(50, 5, gameMap, xSpawn, ySpawn);

                while (gameMap.CollisionDetection(potion.X, potion.Y))
                {
                    xSpawn = gameMap.Random.Next(1, gameMap.width - 1);
                    ySpawn = gameMap.Random.Next(1, gameMap.height - 1);
                    potion.X = xSpawn;
                    potion.Y = ySpawn;
                }

                Console.SetCursorPosition(potion.X, potion.Y);
                Console.WriteLine("H");

                gameMap.AddItem(potion);
            }
        }



        public override void Use()
        {
            Console.WriteLine($"Using {Name} to restore {Health} health.");
        }
    }
}
