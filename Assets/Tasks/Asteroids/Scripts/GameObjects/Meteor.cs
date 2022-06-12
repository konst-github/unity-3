using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Meteor : TargetObject
    {
        [SerializeField] private ParticleSystem particleOnDestroy;
        [SerializeField] private List<Collectible> collectibles;
        [SerializeField] private Meteor meteorPrefab;

        private const float healthLevel1 = 1;
        private const float healthLevel2 = 0.75f;
        private const float healthLevel3 = 0.30f;
        private const float healthLevel4 = 0.02f;

        private int healthLevel = 0;
        private int damageLevel = 0;

        private void Start()
        {
            healthLevel = health;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag.Equals(Tag.PlayerLaser))
            {
                Debug.Log("METEOR: OnCollisionEnter2D LASER");

                Laser laser = collision.collider.GetComponent<Laser>();

                healthLevel -= laser.laser.damage;

                if(healthLevel <= (health * healthLevel3) && damageLevel < 2)
                {
                    transform.localScale = Vector2.one * 0.5f;
                    damageLevel = 2;
                    Split(2, 0.5f, healthLevel);
                }
                else if(healthLevel <= (health * healthLevel2) && damageLevel < 1)
                {
                    transform.localScale = Vector2.one * 0.75f;
                    damageLevel = 1;
                    Split(1, 0.75f, healthLevel);
                }

                Destroy(collision.collider.gameObject);

                AnimateDamage();

                if (healthLevel <= (health * healthLevel4))
                {
                    StartCoroutine("DestroyMeteor");
                }                
            }
            else if (collision.collider.tag.Equals(Tag.Bounds))
            {
                Debug.Log("METEOR: OnCollisionEnter2D BOUNDS");
                Destroy(gameObject);
            }
        }

        private void Split(int newMeteorsCount, float scale, int health)
        {
            for(int index = 0; index < newMeteorsCount; index++)
            {
                Meteor newMeteor = Instantiate(meteorPrefab);
                newMeteor.transform.position = transform.position;
                newMeteor.transform.localScale = Vector2.one * scale;
                newMeteor.health = health;
                newMeteor.damageLevel = damageLevel;
                newMeteor.GetComponent<Rigidbody2D>().AddRelativeForce(Random.insideUnitCircle * 3);
            }
        }

        public void SetMass(float mass)
        {
            GetComponent<Rigidbody2D>().mass = mass;
        }

        public void SetPositionAndForce(Vector3 position, Vector2 force)
        {
            transform.position = position;
            GetComponent<Rigidbody2D>().AddRelativeForce(force);
        }

        private void AnimateDamage()
        {
            if (!particleOnDestroy.isPlaying)
            {
                particleOnDestroy.Play();
            }
        }

        private IEnumerator DestroyMeteor()
        {
            yield return new WaitForSeconds(particleOnDestroy.main.duration);


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
}