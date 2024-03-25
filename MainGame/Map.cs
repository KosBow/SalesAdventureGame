using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure3000.MainGame
{
    internal class Map
    {
        private int width;
        private int height;


        public Map(int mapWidth, int mapHeight)
        {
            width = mapWidth;
            height = mapHeight;
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
        public void SpawnPlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.WriteLine("@");
        }
    }
}
