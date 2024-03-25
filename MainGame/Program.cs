using MMORPG.MainGame.UI;

namespace SalesAdventure3000.MainGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mapWidth = 100;
            int mapHeight = 30;

            Map gameMap = new Map(mapWidth, mapHeight);
            //UI.UI ui = new UI.UI();
            Player player = new Player(mapWidth / 2, mapHeight / 2, gameMap);



            gameMap.SpawnPlayer(player);
            //ui.Healthbar(player, player.Health);
            while (true)
            {
                gameMap.MapRender();
                player.PlayerMovement();

            }
        }
    }
}
