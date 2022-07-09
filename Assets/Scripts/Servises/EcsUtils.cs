using System;

namespace ButtonsAndDoors
{
    public class EcsUtils
    {
        public static float V3Dis(V3 v1, V3 v2)
        {
            double num1 = v1.x - v2.x;
            double num2 = v1.y - v2.y;
            double num3 = v1.z - v2.z;
            return (float) Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3);
        }

        public static V3 Lerp(V3 v1, V3 v2, float t)
        {
            t = t > 1 ? 1 : t < 0 ? 0 : t;
            float num1 = v1.x + (v2.x - v1.x) * t;
            float num2 = v1.y + (v2.y - v1.y) * t;
            float num3 = v1.z + (v2.z - v1.z) * t;
            return new V3(num1, num2, num3);
        }
    }
}