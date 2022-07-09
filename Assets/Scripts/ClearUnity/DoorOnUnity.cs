using UnityEngine;

namespace ButtonsAndDoors.ClearUnity
{
    public class DoorOnUnity : MonoBehaviour
    {
        public Constatns.TypeID colorID;
        public MeshRenderer meshRenderer;

        public void SetColor(Color clr)
        {
            meshRenderer.material.color = clr;
        }
    }
}