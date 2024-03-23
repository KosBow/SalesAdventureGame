namespace SalesAdventure3000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mapWidth = 120;
            int mapHeight = 10;
            Map gameMap = new Map(mapWidth, mapHeight);
            //while (true)
            //{
                gameMap.mapRendering();
            //}
        }
    }
}
