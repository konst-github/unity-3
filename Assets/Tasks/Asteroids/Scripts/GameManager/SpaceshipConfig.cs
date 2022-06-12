
using System.Collections.Generic;

namespace Asteroids
{
    public class SpaceshipConfig
    {
        private static Dictionary<string, SpaceshipConfig> configs = new Dictionary<string, SpaceshipConfig>();

        public int health = 0;
        public int rotateSpeed = 0;
        public int moveSpeed = 0;

        public float dashSpeed = 0;
        public int fuel = 0;
        public int dashConsumption = 0;

        public int shieldTimeout = 0;

        public int dragForce = 0;

        public float shootCoolDown = 0;
        public Laser laser;

        public static void InitConfigs()
        {
            if(configs.Count == 0)
            {
                configs[Spaceship.ship1] = Config1();
                configs[Spaceship.ship2] = Config2();
                configs[Spaceship.ship3] = Config3();
                configs[Tag.EnemySpaceship] = ConfigEnemy();
            }
        }

        public static SpaceshipConfig ConfigForShip(string shipName)
        {
            return configs[shipName];
        }

        private static SpaceshipConfig Config1()
        {
            SpaceshipConfig spaceshipConfig = new SpaceshipConfig();

            spaceshipConfig.health = 100;
            spaceshipConfig.rotateSpeed = 2;
            spaceshipConfig.moveSpeed = 5;

            spaceshipConfig.dashSpeed = 1.3f;
            spaceshipConfig.fuel = 100;
            spaceshipConfig.dashConsumption = 10;

            spaceshipConfig.shieldTimeout = 10;

            spaceshipConfig.dragForce = 1;

            spaceshipConfig.shootCoolDown = 0.25f;
            spaceshipConfig.laser.speed = 3f;
            spaceshipConfig.laser.damage = 1;

            return spaceshipConfig;
        }

        private static SpaceshipConfig Config2()
        {
            SpaceshipConfig spaceshipConfig = new SpaceshipConfig();

            spaceshipConfig.health = 100;
            spaceshipConfig.rotateSpeed = 3;
            spaceshipConfig.moveSpeed = 6;

            spaceshipConfig.dashSpeed = 1.4f;
            spaceshipConfig.fuel = 110;
            spaceshipConfig.dashConsumption = 10;

            spaceshipConfig.shieldTimeout = 10;

            spaceshipConfig.dragForce = 1;

            spaceshipConfig.shootCoolDown = 0.2f;
            spaceshipConfig.laser.speed = 4.5f;
            spaceshipConfig.laser.damage = 2;

            return spaceshipConfig;
        }

        private static SpaceshipConfig Config3()
        {
            SpaceshipConfig spaceshipConfig = new SpaceshipConfig();

            spaceshipConfig.health = 100;
            spaceshipConfig.rotateSpeed = 2;
            spaceshipConfig.moveSpeed = 5;

            spaceshipConfig.dashSpeed = 1.5f;
            spaceshipConfig.fuel = 120;
            spaceshipConfig.dashConsumption = 10;

            spaceshipConfig.shieldTimeout = 10;

            spaceshipConfig.dragForce = 1;

            spaceshipConfig.shootCoolDown = 0.15f;
            spaceshipConfig.laser.speed = 6f;
            spaceshipConfig.laser.damage = 3;

            return spaceshipConfig;
        }

        private static SpaceshipConfig ConfigEnemy()
        {
            SpaceshipConfig spaceshipConfig = new SpaceshipConfig();

            spaceshipConfig.health = 30;
            spaceshipConfig.rotateSpeed = 2;
            spaceshipConfig.moveSpeed = 1;

            spaceshipConfig.dashSpeed = 0;
            spaceshipConfig.fuel = 0;
            spaceshipConfig.dashConsumption = 10;

            spaceshipConfig.shieldTimeout = 0;

            spaceshipConfig.dragForce = 0;

            spaceshipConfig.shootCoolDown = 0.2f;
            spaceshipConfig.laser.speed = 5f;
            spaceshipConfig.laser.damage = 3;

            return spaceshipConfig;
        }

        public struct Laser
        {
            public float speed;
            public int damage;
        }
    }
}