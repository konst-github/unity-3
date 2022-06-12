
using UnityEngine;

public class Utils
{
    public class Random
    {
        public static float Sign()
        {
            return UnityEngine.Random.value >= 0.5 ? 1 : -1;
        }
    }
}
