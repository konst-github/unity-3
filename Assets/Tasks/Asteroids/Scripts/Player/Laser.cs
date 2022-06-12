using UnityEngine;

namespace Asteroids
{
    public class Laser : MonoBehaviour
    {
        private SpaceshipConfig.Laser _laser;
        public SpaceshipConfig.Laser laser => _laser;

        private void Update()
        {
            transform.position += transform.rotation * Vector2.up * (laser.speed * Time.deltaTime);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag.Equals(Tag.Bounds))
            {
                Debug.Log("LASER: OnCollisionEnter2D: BOUNDS");
                Destroy(gameObject);
            }
        }

        public void SetParams(SpaceshipConfig.Laser laserParams)
        {
            _laser = laserParams;
        }

        public void SetRotation(Quaternion rot)
        {
            transform.rotation = rot;
        }

    }
}