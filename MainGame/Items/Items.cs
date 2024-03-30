using MMORPG.MainGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.MainGame.Items
{
    internal abstract class Item
    {
        public string Name { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Item(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public abstract void Use();

    }
}
