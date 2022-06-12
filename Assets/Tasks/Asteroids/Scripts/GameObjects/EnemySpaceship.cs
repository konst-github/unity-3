using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemySpaceship : MonoBehaviour
    {
        [SerializeField] private List<Sprite> shipSprites;
        [SerializeField] private Laser laserPrefab;
        [SerializeField] private GameObject laserGenerator;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<Collectible> collectibles;

        private SpaceshipConfig config;
        private int healthLevel;

        private void Awake()
        {
            config = SpaceshipConfig.ConfigForShip(Tag.EnemySpaceship);
            healthLevel = config.health;
            int index = Random.Range(0, shipSprites.Count);
            spriteRenderer.sprite = shipSprites[index];
        }

        private void Shoot()
        {
            Laser laser = Instantiate(laserPrefab, laserGenerator.transform);
            laser.SetParams(config.laser);
            laser.SetRotation(transform.rotation);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag.Equals(Tag.PlayerLaser))
            {
                Debug.Log("ENEMY: OnCollisionEnter2D LASER");

                Laser laser = collision.collider.GetComponent<Laser>();

                healthLevel -= laser.laser.damage;

                Destroy(collision.collider.gameObject);

                if (healthLevel <= 0)
                {
                    Destroy(gameObject);

                    int value = Random.Range(0, 100);
                    Collectible collectible;
                    // TODO: move chances to Inspector
                    if (value > 50)
                    {
                        collectible = Instantiate(collectibles[2]);
                    }
                    else if (value > 25)
                    {
                        collectible = Instantiate(collectibles[0]);
                    }
                    else
                    {
                        collectible = Instantiate(collectibles[1]);
                    }

                    collectible.transform.position = transform.position;
                    Destroy(gameObject);
                }
            }
            else if (collision.collider.tag.Equals(Tag.Bounds))
            {
                Debug.Log("ENEMY: OnCollisionEnter2D BOUNDS");
                Destroy(gameObject);
            }
        }

        public void SetPositionAndForce(Vector3 position, Vector2 force)
        {
            transform.position = position;
            GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * config.moveSpeed * 10);
        }
    }
}