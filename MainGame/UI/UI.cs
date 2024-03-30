using SalesAdventure.MainGame;
using SalesAdventure.MainGame.Enemies;
using SalesAdventure.MainGame.Items;
using SalesAdventure3000.MainGame;
using System;
using System.Collections.Generic;

namespace MMORPG.MainGame.UI
{
    internal class UI
    {
        public int mapWidth;
        public int mapHeight;

        public UI(int mapWidth, int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
        }

        public void Inventory(Map gameMap, List<Item> items)
        {
            int uiPosX = gameMap.width + 1;
            int uiPosY = 0;

            Console.SetCursorPosition(uiPosX, uiPosY);
            Console.WriteLine("--- Inventory ---");

            int itemPosY = uiPosY + 1;

            var groupedItems = items.GroupBy(item => item.Name);

            foreach (var group in groupedItems)
            {
                Console.SetCursorPosition(uiPosX, itemPosY);
                Console.WriteLine($"{group.Key} (x{group.Count()})");
                itemPosY++;
            }
        }


        public void PlayerInformation(Map gameMap, Player player)
        {
            int uiPosX = gameMap.width + 1;
            int uiPosY = 10;

            Console.SetCursorPosition(uiPosX, uiPosY);
            Console.WriteLine("Player Information");

            int infoPosY = uiPosY + 1;

            Console.SetCursorPosition(uiPosX, infoPosY);
            Console.WriteLine("Health: " + player.Health);

            Console.SetCursorPosition(uiPosX, infoPosY + 1);
            Console.WriteLine("Energy: " + player.Energy);
        }


        public void FightInformation(Map gameMap, Player player, List<Goblin> goblins)
        {
            int uiPosX = (Console.WindowWidth - 25) / 2;
            int uiPosY = 10;

            Console.SetCursorPosition(uiPosX, uiPosY);
            Console.WriteLine("--- Fight Information ---");

            int infoPosY = uiPosY + 1;

            Console.SetCursorPosition(uiPosX, infoPosY);
            Console.WriteLine($"Player Health: {player.Health}");

            Console.SetCursorPosition(uiPosX, infoPosY + 1);
            Console.WriteLine($"Player Energy: {player.Energy}");

            foreach (var enemy in goblins)
            {
                Console.SetCursorPosition(uiPosX, infoPosY + 3);
                Console.WriteLine($"Name: {enemy.Name}");

                int healthPosY = infoPosY + 4;
                Console.SetCursorPosition(uiPosX, healthPosY);
                Console.WriteLine($"Health: {enemy.Health}");

                infoPosY += 6;
            }
        }

        public void CenterText(string text, Map gamepMap)
        {
            int screenWidth = gamepMap.width;
            int screenHeight = gamepMap.height;
            int textLength = text.Length;

            int xPos = (screenWidth - textLength) / 2;
            int yPos = screenHeight / 2;

            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine(text);
        }
    }
}

