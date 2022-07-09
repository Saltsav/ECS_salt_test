using System;

namespace ButtonsAndDoors
{
    [Serializable]
    public class V3
    {
        public float x;
        public float y;
        public float z;

        public V3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}