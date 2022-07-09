using System;

namespace ButtonsAndDoors
{
    [Serializable]
    public class Clr
    {
        public float r;
        public float g;
        public float b;

        public Clr(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}