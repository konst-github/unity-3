using UnityEngine;

namespace Asteroids
{
    public class GameScene : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("GameScene AWAKE");
            GameManager.Instance.ConfigureGame(Spaceship.ship3, GameMode.Scorer);
        }
    }
}