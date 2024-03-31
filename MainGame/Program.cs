using MMORPG.MainGame.UI;
using MMORPG.MainGame;
using SalesAdventure.MainGame.Enemies;
using SalesAdventure.MainGame.Items;
using SalesAdventure3000.MainGame;
using System;
using System.Collections.Generic;
using SalesAdventure3000.MainGame.Fighting;

namespace SalesAdventure.MainGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WindowWidth = 120; - Ruined the map so disabled for now.
            //Console.WindowHeight = 35;

            GameState gameState = InitializeGameState();
            GameLoop(gameState);
        }

        static GameState InitializeGameState()
        {
            int mapWidth = 100;
            int mapHeight = 30;

            Map gameMap = new Map(mapWidth, mapHeight);
            Inventory inventory = new Inventory();
            List<Item> items = new List<Item>();
            List<Goblin> goblins = new List<Goblin>();
            Player player = new Player("Ahmed", 100, 100, mapWidth / 2, mapHeight / 2, gameMap, inventory, items);
            HealthPotion healthPotion = new HealthPotion(50, 1, gameMap, 0, 0);
            healthPotion.SpawnHealthPotion(gameMap, 5);
            EnergyPotion energyPotion = new EnergyPotion(10, 1, gameMap, 0, 0);
            energyPotion.SpawnEnergyPotion(gameMap, 2);
            gameMap.SpawnPlayer(player.X, player.Y);



            Goblin goblin = new Goblin(30, 0, 0);
            goblin.SpawnGoblin(gameMap, 5);
            goblins.Add(goblin);

            return new GameState(player, items, gameMap, goblins);
        }

        static void GameLoop(GameState gameState)
        {
            Console.CursorVisible = false;
            UI ui = new UI(gameState.GameMap.width, gameState.GameMap.height);
            bool inFight = false;

            List<Goblin> goblins = gameState.goblin;

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                gameState.GameMap.MapRender();
                ui.PlayerInformation(gameState.GameMap, gameState.Player);
                ui.Inventory(gameState.GameMap, gameState.items);

                if (inFight)
                {
                    gameState.GameMap.RemoveAllItems();
                    FightManager.Fight(gameState.Player, gameState.goblin[0], gameState, ui);

                    Console.Clear();
                    inFight = false;

                    RespawnObjects(gameState);
                    gameState.GameMap.MapRender();
                }
                else
                {
                    gameState.Player.PlayerMovement(gameState.items);
                    gameState.Player.pickUpItem(gameState.Player);

                    if (goblins != null && goblins.Count > 0 && gameState.Player.IsCloseToGoblin(gameState.Player, goblins))
                    {

                        ui.CenterText("A goblin is nearby! Press (Y) to Fight it (press Enter)", gameState.GameMap);
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "y")
                        {
                            inFight = true;
                            gameState.GameMap.RemoveEnemy(goblins[0]);
                            Console.Clear();
                        }
                    }
                    //Console.SetCursorPosition(0, gameState.GameMap.height + 2); - Ruined the map so disabled for now.
                }
            }
        }

        static void RespawnObjects(GameState gameState)
        {
            gameState.GameMap.Goblins.Clear();

            int goblinBaseHealth = 10;
            int goblinHealthIncrement = 2;
            int numberOfGoblins = 2;

            int currentGoblinHealth = goblinBaseHealth;

            for (int i = 0; i < numberOfGoblins; i++)
            {
                Goblin newGoblin = new Goblin(currentGoblinHealth, 0, 0);
                newGoblin.SpawnGoblin(gameState.GameMap, 3);
                gameState.GameMap.AddEnemy(newGoblin);

                currentGoblinHealth += goblinHealthIncrement;
            }


            HealthPotion healthPotion = new HealthPotion(50, 5, gameState.GameMap, 0, 0);
            gameState.GameMap.SpawnHealthPotion(healthPotion);
            EnergyPotion energyPotion = new EnergyPotion(10, 1, gameState.GameMap, 0, 0);
            gameState.GameMap.SpawnEnergyPotion(energyPotion);

            foreach (var item in gameState.items)
            {
                gameState.GameMap.AddItem(item);
            }

            gameState.inFight = false;
        }

    }
}