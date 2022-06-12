using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public class MeteorsSpawner : SpawnerBase
    {
        [SerializeField] private Meteor greyMeteorPrefab;
        [SerializeField] private Meteor brownMeteorPrefab;
        [SerializeField] private Meteor goldenMeteorPrefab;

        private float meteorMass = 1;

        protected override IEnumerator Spawn()
        {
            while (true)
            {
                if (spawnerPoints.Count > 0)
                {
                    GameObject spawnPoint = AwailableSpawnPoint();
                    Vector2 direction = spawnPoint.transform.position / spawnPoint.transform.position.magnitude;

                    Meteor meteor = Instantiate(RandomPrefab());
                    meteor.SetPositionAndForce(spawnPoint.transform.position, -Vector2.one * direction * forceMultiplier);
                    meteor.SetMass(meteorMass);
                }
                yield return base.Spawn();
            }
        }

        protected override IEnumerator LevelUp()
        {
            while(true)
            {
                yield return new WaitForSeconds(levelUpTimeout);
                spawnInterval /= levelUpIncrease;
                forceMultiplier *= levelUpIncrease;
                meteorMass *= levelUpIncrease;
            }
        }

        private Meteor RandomPrefab()
        {
            int random = Random.Range(0, 100);

            if(random > 100 - 12.5)
            {
                return goldenMeteorPrefab;
            }
            else if(random < (100-12.5) && random > (100 - 30))
            {
                return brownMeteorPrefab;
            }
            else
            {
                return greyMeteorPrefab;
            }
        }
    }
}