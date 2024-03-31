using MMORPG.MainGame;
using SalesAdventure3000.MainGame;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SalesAdventure.MainGame.Items
{
    internal class Inventory
    {
        private List<Item> items;
        private Map gameMap;

        public Inventory()
        {
            this.items = new List<Item>();
        }

        public void AddItem(Item item, Map gameMap)
        {
            items.Add(item);

            int xPosition = (gameMap.width - $"You have picked up a {item.Name}".Length) / 2;
            int yPosition = gameMap.height / 2;

            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine($"You have a: {item.Name}");
            Thread.Sleep(500);
            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine(new string(' ', $"You have a: {item.Name}".Length));


        }

        public void DisplayInventory()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
