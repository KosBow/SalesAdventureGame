using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure3000
{
    internal class Player
    {
       
        public int positionX { get; private set; }
        public int positionY { get; private set; }
    
    public Player(int playerPositionX, int playerPositionY)
        {

            this.positionX = playerPositionX;
            this.positionY = playerPositionY;
        }
        public void playerMovment()
        {
            if (Console.KeyAvailable)
            {
                var command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.DownArrow:
                        positionY++;
                        break;
                    case ConsoleKey.UpArrow:
                        positionY--;
                        break;
                    case ConsoleKey.LeftArrow:
                        positionX++;
                        break;
                    case ConsoleKey.RightArrow:
                        positionX--;
                        break;
                }
                Console.SetCursorPosition((int)positionX,(int)positionY);
                Console.Write('@');
            }
        }
    }
}
