using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TargetObject : MonoBehaviour
    {
        [SerializeField] public int points = 0;
        [SerializeField] public int health = 0;
        [SerializeField] public int damage = 0;
        [SerializeField] public int price = 0;
    }
}