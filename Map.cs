using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure3000
{
    internal class Map
    {
        public int height;
        public int width;
        public Map(int MapWidth, int MapHeight)
        {
            this.height = MapHeight;
            this.width = MapWidth;
        }
        public void mapRendering()
        { //Nested Loop!
            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if (i == 0 || i == width - 1)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("#");
                    }
                    else if (j == 0 || j == height - 1)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("#");
                    }
                }
            }
        }
    }
    public void spawnPlayer(Player player)
    {
        Console.SetCursorPosition(player.positionX);
    }
}