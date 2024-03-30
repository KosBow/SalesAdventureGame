using MMORPG.MainGame;
using MMORPG.MainGame.UI;
using SalesAdventure.MainGame.Enemies;
using SalesAdventure.MainGame.Items;
using SalesAdventure3000.MainGame;
using System;

namespace SalesAdventure.MainGame
{
    internal static class FightManager
    {
        public static void Fight(Player player, Goblin goblin, GameState gameState, UI ui)
        {
            if (player.Health <= 0 || player.Energy <= 0)
            {
                ui.CenterText("Your Energy level is too low to fight", gameState.GameMap);
                return;
            }

            ui.CenterText("You have encountered a Goblin and it's ready to fight. (press enter)", gameState.GameMap);
  
            Console.ReadLine();
            Console.Clear();
            gameState.GameMap.RemoveAllItems();

            ui.FightInformation(gameState.GameMap, player, gameState.goblin);

            while (player.Health > 0 && player.Energy > 0 && goblin.Health > 0)
            {
                // Player tur
                PlayerTurn(player, goblin, ui, gameState.GameMap, gameState.goblin, gameState.items);
                if (goblin.Health <= 0)
                {
                    Console.WriteLine("You defeated the goblin!");
                    player.Energy += 20;
                    if (player.Energy > 100)
                    {
                        player.Energy = 100;
                    }
                    Console.WriteLine("You got 20 Energy points as reward Current Energy: " + player.Energy);
                    gameState.GameMap.RemoveEnemy(goblin);

                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    RespawnObjects(gameState);
                    ResetGameState(gameState);
                    return;
                }

                // Goblin tur
                GoblinTurn(player, goblin);

                if (player.Health <= 0)
                {
                    Console.Clear();
                    ui.CenterText("You were defeated by the goblin! Press a Key to Exit the SalesAdventure", gameState.GameMap);
                    Thread.Sleep(1000);
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }
        }



        private static int GetPlayerChoice(Map gameMap, Player player, List<Goblin> goblins, UI ui)
        {

            ui.FightInformation(gameMap, player, goblins);

            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Basic Attack :5 Energycost DMG: 1-6");
            Console.WriteLine("2. Use Health Potion");
            Console.WriteLine("3. Use Energy Potion");
            Console.WriteLine("4. Show Inventory");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!");
                return -1;
            }

            return choice;
        }

        private static void PlayerTurn(Player player, Goblin goblin, UI ui, Map gameMap, List<Goblin> goblins, List<Item> items)
        {
            int choice;
            do
            {
                Console.Clear();
                choice = GetPlayerChoice(gameMap, player, goblins, ui);

                switch (choice)
                {
                    case 1:
                        player.basicAttack(goblin);
                        break;
                    case 2:
                        player.useHealthPotion();
                        break;
                    case 3:
                        player.useEnergyPotion();
                        break;
                    case 4:
                        player.ShowInventory(items);
                        break;
                    default:
                        Console.WriteLine("Invalid action!");
                        break;
                }

                Console.WriteLine("Press Enter to end your turn");
                Console.ReadLine();
            } while (choice < 1 || choice > 3);
        }



        static void ResetGameState(GameState gameState)
        {
            Console.Clear();

            gameState.GameMap.MapRender();

            gameState.GameMap.SpawnPlayer(gameState.Player.X, gameState.Player.Y);

            foreach (var goblin in gameState.goblin)
            {
                goblin.Health = 30;
            }

            foreach (var item in gameState.items)
            {
                gameState.GameMap.AddItem(item);
            }
        }
        static void RespawnObjects(GameState gameState)
        {
            gameState.GameMap.Goblins.Clear();

            int goblinBaseHealth = 30;
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

    static void GoblinTurn(Player player, Goblin goblin)
        {
            Random random = new Random();
            int damage = random.Next(1, 20);
            goblin.Attack(player, damage);
        }
    }
}
