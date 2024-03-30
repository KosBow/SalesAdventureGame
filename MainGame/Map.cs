using MMORPG.MainGame;
using SalesAdventure.MainGame;
using SalesAdventure.MainGame.Enemies;
using SalesAdventure.MainGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure3000.MainGame
{
    internal class Map
    {
        public int width;
        public int height;
        internal object items;

        public Random Random { get; private set; }
        public List<Item> Items { get; private set; }
        public List<Goblin> Goblins { get; private set; }
        public Map(int mapWidth, int mapHeight)
        {
            width = mapWidth;
            height = mapHeight;
            Items = new List<Item>();
            Random = new Random();
            Goblins = new List<Goblin>();
        }

        public void MapRender()
        {
            Console.CursorVisible = false;
            //Draw Border
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write("#");
                        }
                    }
                }
            }
        }
        public bool CollisionDetection(int x, int y)
        {
            return x <= 0 || x >= width - 1 || y <= 0 || y >= height - 1;
        }


        //Player Spawn
        public void SpawnPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("@");
        }
        //Goblin Spawn
        public void GoblinSpawn(Goblin goblin)
        {
            goblin.SpawnGoblin(this, 5);
            Goblins.Add(goblin);
        }
        //HealthPotions
        public void SpawnHealthPotion(HealthPotion healthPotion)
        {
            healthPotion.SpawnHealthPotion(this, 5);
        }
        public void SpawnEnergyPotion(EnergyPotion energyPotion)
        {
            energyPotion.SpawnEnergyPotion(this, 2);
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void AddEnemy(Goblin goblin)
        {
            Goblins.Add(goblin);
        }
        public void RemoveItem(int x, int y)
        {
            Items.RemoveAll(item => item.X == x && item.Y == y);
        }
        public void RemoveAllItems()
        {
            Items.Clear();
        }

        public void RemoveEnemy(Goblin goblin)
        {
            if (goblin != null)
            {
                Goblins.Remove(goblin);
            }
        }

    }
}
