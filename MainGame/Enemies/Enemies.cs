using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.MainGame.Enemies
{
    internal abstract class Enemies
    {
        public string Name { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }

        public Enemies(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }

}
