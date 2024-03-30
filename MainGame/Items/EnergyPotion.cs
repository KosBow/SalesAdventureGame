using MMORPG.MainGame;
using SalesAdventure3000.MainGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.MainGame.Items
{
    internal class EnergyPotion : Item
    {
        public int Energy { get; set; }
        public int Spawn { get; set; }

        private Map gameMap;

        public EnergyPotion(int energy, int spawns, Map gameMap, int x, int y) : base ("EnergyPotion", x, y)
        {
            this.Energy = energy;
            this.Spawn = spawns;
            this.gameMap = gameMap;
        }
        public void SpawnEnergyPotion(Map gameMap, int numberOfPotions)
        {
            for (int i = 0; i < numberOfPotions; i++)
            {
                int xSpawn = gameMap.Random.Next(1, gameMap.width - 1);
                int ySpawn = gameMap.Random.Next(1, gameMap.height - 1);

                EnergyPotion potion = new EnergyPotion(10, 2, gameMap, xSpawn, ySpawn);

                while (gameMap.CollisionDetection(potion.X, potion.Y))
                {
                    xSpawn = gameMap.Random.Next(1, gameMap.width - 1);
                    ySpawn = gameMap.Random.Next(1, gameMap.height - 1);
                    potion.X = xSpawn;
                    potion.Y = ySpawn;
                }

                Console.SetCursorPosition(potion.X, potion.Y);
                Console.WriteLine("E");

                gameMap.AddItem(potion);
            }
        }
        public override void Use()
        {
            Console.WriteLine($"Using {Name} to restore {Energy} Energy.");
        }
    }
}
