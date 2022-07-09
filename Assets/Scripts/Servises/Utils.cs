using UnityEngine;

namespace ButtonsAndDoors
{
    public class Utils
    {
        public static V3 ConvertVector3ToV3(Vector3 v3unity)
        {
            return new V3(v3unity.x, v3unity.y, v3unity.z);
        }

        public static Vector3 ConvertV3ToVector3(V3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static Clr ConvertColorToClr(Color color)
        {
            return new Clr(color.r, color.g, color.b);
        }

        public static Color ConvertClrToColor(Clr clr)
        {
            return new Color(clr.r, clr.g, clr.b);
        }
    }
}