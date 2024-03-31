using SalesAdventure.MainGame;
using SalesAdventure.MainGame.Enemies;
using SalesAdventure.MainGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesAdventure3000.MainGame
{
    internal class GameState
    {
        public Player Player { get; set; }
        public List<Item> items { get; set; }
        public List<Goblin> goblin { get; set; }
        public bool inFight = false;




        public Map GameMap { get; set; }
        public Goblin Goblin { get; set; }

        public GameState(Player player, List<Item> items, Map gameMap, List<Goblin> goblins)
        {
            Player = player;
            this.items = items;
            GameMap = gameMap;
            goblin = goblins;
        }
    }
}
