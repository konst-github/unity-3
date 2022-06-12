using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class SpawnerBase : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> spawnerPoints;
        [SerializeField] protected float spawnInterval;

        protected float forceMultiplier = 15;

        protected const float levelUpTimeout = 30;
        protected const float levelUpIncrease = 1.25f;

        protected const string coroutineSpawnName = "Spawn";
        protected const string coroutineLevelUpName = "LevelUp";

        private void Start()
        {
            StartCoroutine(coroutineSpawnName);
            StartCoroutine(coroutineLevelUpName);
        }

        protected GameObject AwailableSpawnPoint()
        {
            int index = Random.Range(0, spawnerPoints.Count);
            return spawnerPoints[index];
        }

        protected virtual IEnumerator Spawn()
        {
            yield return new WaitForSeconds(spawnInterval);
        }

        protected virtual IEnumerator LevelUp()
        {
            yield return new WaitForSeconds(levelUpTimeout);
        }
    }
}