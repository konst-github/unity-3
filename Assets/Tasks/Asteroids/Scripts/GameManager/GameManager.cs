
namespace Asteroids
{
    public class GameManager
    {
        private static GameManager _instance = new GameManager();
        public static GameManager Instance => _instance;

        public string shipType = "";
        public string gameMode = "";
        public SpaceshipConfig activeConfig;
        
        public string gameOverType = "";

        public void ConfigureGameDebug()
        {
            ConfigureGame(shipType, gameMode);
        }

        public void ConfigureGame(string shipType, string gameMode)
        {
            this.shipType = shipType;
            this.gameMode = gameMode;

            SpaceshipConfig.InitConfigs();
            activeConfig = SpaceshipConfig.ConfigForShip(shipType);
        }
    }
}