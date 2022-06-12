using UnityEngine;

namespace Asteroids
{
    public class BoundController : MonoBehaviour
    {
        public BoundController oppositeBound;

        public bool isVertical()
        {
            return transform.localScale.y > transform.localScale.x;
        }
    }
}