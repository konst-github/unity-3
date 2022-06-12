using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public class PlayerSpaceship : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private List<Sprite> shipSprites;
        [SerializeField] private List<Laser> laserPrefabs;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject laserGenerator;

        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private SpaceshipShield shield;
        [SerializeField] private Animation damageAnimation;

        [SerializeField] PlayerStateProgressBar uiFuelBar;
        [SerializeField] PlayerStateProgressBar uiHealthBar;
        [SerializeField] ScoreValueContainer uiScoreText;

        private SpaceshipConfig config;
        private Laser laserPrefab;

        private float lastShootTime;

        private int fuelLevel;
        private int maxFuelLevel;

        private int healthLevel;
        private int maxHealthLevel;

        private int score;

        private void Start()
        {
            ConfigureShipsLook(GameManager.Instance.shipType);

            config = GameManager.Instance.activeConfig;
            maxFuelLevel = fuelLevel = config.fuel;
            maxHealthLevel = healthLevel = config.health;
            score = 0;

            uiFuelBar.SetMaxValue(maxFuelLevel);
            uiHealthBar.SetMaxValue(maxHealthLevel);
            uiScoreText.UpdateValue(score);

            //StartCoroutine("TestUI");
            //StartCoroutine("TestShield");
        }

        private void Update()
        {
            Dash();
            Fire();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void ConfigureShipsLook(string shipType)
        {
            switch (shipType)
            {
                case Spaceship.ship1:
                    spriteRenderer.sprite = shipSprites[0];
                    laserPrefab = laserPrefabs[0];
                    break;
                case Spaceship.ship2:
                    spriteRenderer.sprite = shipSprites[1];
                    laserPrefab = laserPrefabs[1];
                    break;
                case Spaceship.ship3:
                    spriteRenderer.sprite = shipSprites[2];
                    laserPrefab = laserPrefabs[2];
                    break;
            }
        }

        private void Move()
        {
            float horizontalInput = Input.GetAxis(InputSystem.axisHorizontal);
            if (horizontalInput != 0)
            {
                //rigidBody.rotation += (-config.rotateSpeed * horizontalInput * 5);
                rigidBody.AddTorque(-config.rotateSpeed * horizontalInput);
            }

            float verticalInput = Input.GetAxis(InputSystem.axisVertical);
            if (verticalInput != 0)
            {
                rigidBody.AddRelativeForce(Vector2.up * config.moveSpeed * verticalInput);
            }
        }

        private void Dash()
        {
            if (Input.GetButtonDown(InputSystem.jump) && fuelLevel >= config.dashConsumption)
            {
                rigidBody.AddRelativeForce(Vector2.up * config.moveSpeed * config.dashSpeed, ForceMode2D.Impulse);
                ConsumeFuel(config.dashConsumption);
            }
        }

        private void Fire()
        {
            if (Input.GetButtonDown(InputSystem.fire1) && Time.time > lastShootTime + config.shootCoolDown)
            {
                lastShootTime = Time.time;

                Laser laser = Instantiate(laserPrefab, laserGenerator.transform);
                laser.SetParams(config.laser);
                laser.SetRotation(transform.rotation);
            }
        }

        private void AddFuel(int fuel)
        {
            fuelLevel = Mathf.Min(fuelLevel + fuel, maxFuelLevel);
            uiFuelBar.UpdateValue(fuelLevel);
        }

        private void ConsumeFuel(int fuel)
        {
            AddFuel(-fuel);
        }

        private void AddHealth(int health)
        {
            healthLevel = Mathf.Min(healthLevel + health, maxHealthLevel);
            uiHealthBar.UpdateValue(healthLevel);

            if(healthLevel <= 0)
            {
                StartCoroutine("Die");
            }
        }

        private void AddDamage(int damage)
        {
            AddHealth(-damage);
        }

        private void AddScore(int points)
        {
            score += points;
            uiScoreText.UpdateValue(score);
        }

        private IEnumerator Die()
        {
            Time.timeScale /= 2;
            yield return new WaitForSeconds(5);
            Time.timeScale *= 2;
            SceneManager.LoadScene(Scene.GameOver);
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag.Equals(Tag.Collectible))
            {
                Collectible collectible = collider.GetComponent<Collectible>();
                switch(collectible.type)
                {
                    case Collectible.Type.Fuel:
                        AddFuel(collectible.value);
                        AddScore(collectible.points);
                        break;
                    case Collectible.Type.Health:
                        AddHealth(collectible.value);
                        AddScore(collectible.points);
                        break;
                    case Collectible.Type.Shield:
                        AddScore(collectible.points);
                        shield.TurnOn(config.shieldTimeout);
                        break;
                }
                Destroy(collectible.gameObject);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag.Equals(Tag.Meteor) && !shield.IsOn())
            {
                Meteor collectible = collision.collider.GetComponent<Meteor>();
                AddDamage(collectible.damage);
                cameraController.StartShake();
            }
            else if (collision.collider.tag.Equals(Tag.Bounds))
            {
                Debug.Log("PLAYER: OnCollisionEnter2D BOUNDS");

                BoundController boundController = collision.collider.GetComponent<BoundController>();
                transform.position = new Vector3(transform.position.x,
                    boundController.transform.position.y - CameraController.cameraSize.y,
                    transform.position.z);
            }
        }


        #region Debug Section

        private int someValue = 100;
        private IEnumerator TestUI()
        {
            while (someValue > 0)
            {
                someValue -= 5;
                uiFuelBar.UpdateValue(someValue);
                uiHealthBar.UpdateValue(someValue);
                yield return new WaitForSeconds(1);
            }
        }

        private IEnumerator TestShield()
        {
            while(true)
            {
                if (!shield.IsOn())
                {
                    shield.TurnOn(config.shieldTimeout);
                }
                yield return new WaitForSeconds(12);
            }
        }

        #endregion
    }
}