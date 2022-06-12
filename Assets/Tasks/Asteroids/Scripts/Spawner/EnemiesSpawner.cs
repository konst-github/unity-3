using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public class EnemiesSpawner : SpawnerBase
    {
        [SerializeField] private EnemySpaceship enemyPrefab;

        protected override IEnumerator Spawn()
        {
            while (true)
            {
                if (spawnerPoints.Count > 0)
                {
                    GameObject spawnPoint = AwailableSpawnPoint();
                    Vector2 direction = spawnPoint.transform.position / spawnPoint.transform.position.magnitude;

                    EnemySpaceship spaceship = Instantiate(enemyPrefab);
                    spaceship.SetPositionAndForce(spawnPoint.transform.position, -Vector2.one * direction);
                }
                yield return base.Spawn();
            }
        }
    }
}
