using UnityEngine;

public static class Extensions
{
    public static Vector3 Reflect(this Vector3 vector, Vector3 inDirection)
    {
        return new Vector3(vector.x * inDirection.x, vector.y * inDirection.y, vector.z * inDirection.z);
    }
}

public static class QuaternionExt
{
    public static Quaternion EulerX(this Quaternion quaternion, float angle)
    {
        return Quaternion.Euler(angle, 0, 0);
    }

    public static Quaternion EulerY(this Quaternion quaternion, float angle)
    {
        return Quaternion.Euler(0, angle, 0);
    }

    public static Quaternion EulerZ(this Quaternion quaternion, float angle)
    {
        return Quaternion.Euler(0, 0, angle);
    }
}