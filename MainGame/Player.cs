using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure3000.MainGame
{
    internal class Player
    {
        public int X { get; private set; }

        public int Y { get; private set; }
        //private UI.UI ui;
        public int Health { get; set; } = 100;

        private Map map;
        public Player(int PostionX, int PostionY, Map map)
        {
            X = PostionX;
            Y = PostionY;
            //this.ui = ui;
            this.map = map;
        }
        public void PlayerMovement()
        {
            if (Console.KeyAvailable)
            {
                var keyInput = Console.ReadKey().Key;

                Console.SetCursorPosition(X, Y);
                Console.Write(" ");

                int prevX = X;
                int prevY = Y;

                int movementAmount = 1;

                switch (keyInput)
                {

                    case ConsoleKey.DownArrow:
                        if (!map.CollisionDetection(X, Y + 1))
                            Y += movementAmount;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (!map.CollisionDetection(X - 1, Y))
                            X -= movementAmount;
                        break;
                    case ConsoleKey.RightArrow:
                        if (!map.CollisionDetection(X + 1, Y))
                            X += movementAmount;
                        break;
                    case ConsoleKey.UpArrow:
                        if (!map.CollisionDetection(X, Y - 1))
                            Y -= movementAmount;
                        break;
                }
                Console.SetCursorPosition(X, Y);
                Console.Write('@');

                Console.SetCursorPosition(prevY, Y);
                Console.Write(' ');
            }
        }
    }
}
