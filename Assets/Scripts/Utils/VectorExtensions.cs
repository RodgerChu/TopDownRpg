using UnityEngine;

namespace Utils
{
    public static class VectorExtensions
    {
        public static Vector2 XY(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}
