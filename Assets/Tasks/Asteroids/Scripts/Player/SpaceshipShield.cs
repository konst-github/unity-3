using System.Collections;

using UnityEngine;

namespace Asteroids
{
    public class SpaceshipShield : MonoBehaviour
    {
        [SerializeField] private PlayerStateProgressBar uiShieldBar;

        private const string coroutineTurnOff = "TurnOff";

        private int shieldTimeout = 0;

        private void Start()
        {
            gameObject.SetActive(false);
            uiShieldBar.UpdateValue(0);
        }

        public bool IsOn()
        {
            return gameObject.activeSelf;
        }

        public void TurnOn(int timeout)
        {
            if(shieldTimeout > 0)
            {
                StopCoroutine(coroutineTurnOff);
            }
            shieldTimeout = timeout;
            uiShieldBar.SetMaxValue(shieldTimeout);
            gameObject.SetActive(true);
            StartCoroutine(coroutineTurnOff);
        }

        private IEnumerator TurnOff()
        {
            while (shieldTimeout >= 0)
            {
                yield return new WaitForSeconds(1);
                shieldTimeout -= 1;
                uiShieldBar.UpdateValue(shieldTimeout);

                if (shieldTimeout == 0)
                {
                    gameObject.SetActive(false);
                    yield return null;
                }
            }
        }
    }
}