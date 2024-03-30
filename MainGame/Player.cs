using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MMORPG.MainGame;
using MMORPG.MainGame.UI;
using SalesAdventure.MainGame.Enemies;
using SalesAdventure.MainGame.Items;
using SalesAdventure3000.MainGame;

namespace SalesAdventure.MainGame
{
    internal class Player
    {
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        private List<Item> items;
        private List<Goblin> goblins;
        public int Health { get; set; } = 100;
        public int Energy { get; set; } = 100;
        public Inventory inventory;
        private Map map;

        public Player(string Name, int Health, int Energy, int positionX, int positionY, Map map, Inventory inventory, List<Item> items)
        {
            X = positionX;
            Y = positionY;
            this.Health = Health;
            this.Energy = Energy;
            this.map = map;
            this.inventory = inventory;
            this.items = items;
        }

        public void PlayerMovement(List<Item> items)
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
        public void basicAttack(Goblin goblin)
        {
            Random random = new Random();
            int basicDamage = random.Next(1, 7);
            int energyCost = 5;
            if (Energy >= 0)
            {
                goblin.TakeDamage(basicDamage);
                Energy -= energyCost;
                Console.WriteLine($"You used a basic Attack! You did :  {basicDamage} damage");
                Console.WriteLine($"Du har nu {Energy} i Energi");
            }
            else
            {
                Console.WriteLine($"Du har inte tillräckligt med energi: {Energy}");
            }

        }
        //health potion funktion
        public void useHealthPotion()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i] is HealthPotion && Health < 100)
                {
                    HealthPotion healthPotion = (HealthPotion)items[i];
                    Health += healthPotion.Health;

                    if (Health > 100)
                    {
                        Health = 100;
                    }

                    items.RemoveAt(i);
                    Console.WriteLine($"Du använde precis en healthpot och har nu {Health} i hp");
                    return;
                }
            }
            Console.WriteLine("Du har inga healthpot eller så har du fullt hp");
        }
        public void useEnergyPotion()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i] is EnergyPotion && Energy < 100)
                {
                    EnergyPotion energyPotion = (EnergyPotion)items[i];
                    Energy += energyPotion.Energy;

                    if (Energy > 100)
                    {
                        Energy = 100;
                    }

                    items.RemoveAt(i);
                    Console.WriteLine($"Du använde precis en engeripot och har nu {Energy} i Energi");
                    return;
                }
            }
            Console.WriteLine("Du har inga energipot eller så har du fullt energi");
        }
        //show inventory
        public List<Item> GetItems()
        {
            return items;
        }
        public void ShowInventory(List<Item> items)
        {
            Console.WriteLine("Inventory: ");

            // Group items by their name
            var groupedItems = items.GroupBy(item => item.Name);

            int itemIndex = 1;
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"{itemIndex}. {group.Key} (x{group.Count()})");
                itemIndex++;
            }
        }
        public bool IsCloseToGoblin(Player player, List<Goblin> goblins)
        {
            foreach (var goblin in map.Goblins.ToList())
            {
                if (player.X == goblin.X && player.Y == goblin.Y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool pickUpItem(Player player)
        {
            foreach (var item in map.Items.ToList())
            {
                if (item is HealthPotion healthPotion && player.X == healthPotion.X && player.Y == healthPotion.Y)
                {
                    player.GetItems().Add(healthPotion);
                    map.RemoveItem(healthPotion.X, healthPotion.Y);
                    inventory.AddItem(healthPotion, map);
                    map.MapRender();
                    return true;
                }
                else if (item is EnergyPotion energyPotion && player.X == energyPotion.X && player.Y == energyPotion.Y)
                {
                    player.GetItems().Add(energyPotion);
                    map.RemoveItem(energyPotion.X, energyPotion.Y);
                    inventory.AddItem(energyPotion, map);
                    map.MapRender();
                    return true;
                }
            }
            return false;
        }


    }
}

