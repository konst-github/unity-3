using UnityEngine;

namespace Asteroids
{
    public class Collectible : MonoBehaviour
    {
        public Type type;    
        public int value;    
        public int points;

        private float lifeTime = 15;

        private void Update()
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        public enum Type
        {
            Fuel,
            Health,
            Shield
        }
    }
}