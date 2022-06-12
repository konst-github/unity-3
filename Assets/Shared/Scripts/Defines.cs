
namespace Asteroids
{
    public class InputSystem
    {
        public const string axisHorizontal = "Horizontal";
        public const string axisVertical = "Vertical";
        public const string jump = "Jump";
        public const string fire1 = "Fire1";
    }

    public class Spaceship
    {
        public const string ship1 = "Spaceship 1";
        public const string ship2 = "Spaceship 2";
        public const string ship3 = "Spaceship 3";
    }

    public class Layer
    {
        public const string UI = "UI";
        public const string Background = "Background";
        public const string Base = "Base";
        public const string Meteors = "Meteors";
        public const string Enemies = "Enemies";
        public const string Collectibles = "Collectibles";
        public const string Player = "Player";
        public const string UFOs = "UFOs";
        public const string PlayerLasers = "PlayerLasers";
        public const string EnemyLasers = "EnemyLasers";
    }

    public class Tag
    {
        public const string Background = "Background";
        public const string Star = "Star";
        public const string Meteor = "Meteor";
        public const string Collectible = "Collectible";
        public const string UFO = "UFO";
        public const string EnemySpaceship = "EnemySpaceship";
        public const string PlayerSpaceship = "PlayerSpaceship";
        public const string RepairBase = "RepairBase";
        public const string MarketplaceBase = "MarketplaceBase";
        public const string PlayerLaser = "PlayerLaser";
        public const string EnemyLaser = "EnemyLaser";
        public const string Bounds = "Bounds";
    }

    public class Scene
    {
        public const string MainMenu = "Scene_Task_3_1_MainMenu";
        public const string GameSetup = "Scene_Task_3_1_GameSetup";
        public const string Game = "Scene_Task_3_1_Game";
        public const string GameOver = "Scene_Task_3_1_GameOver";

    }

    public class GameMode
    {
        public const string Scorer = "Scorer";
        public const string Speeder = "Speeder";
        public const string DieHard = "DieHard";
    }

    public class GameOver
    {
        public const string StateWin = "Win";
        public const string StateLose = "Lose";
        
        public const string TextYouWin = "YOU WIN";
        public const string TextYouLose = "GAME OVER";
        public const string TextScore = "SCORE";
    }
}