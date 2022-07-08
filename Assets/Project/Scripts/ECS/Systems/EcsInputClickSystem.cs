using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsInputClickSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RaycastHit _hit;
        private Ray _ray;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            systems.GetWorld().GetPool<EcsInputClick>().Add(entity);
        }

        public void Run(EcsSystems systems)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit))
                {
                    foreach (int entity in systems.GetWorld().Filter<EcsInputClick>().End())
                    {
                        ref EcsInputClick inputClick = ref systems.GetWorld().GetPool<EcsInputClick>().Get(entity);
                        inputClick.vector3 = _hit.point;
                        inputClick.haveClick = true;
                    }
                }
            }
        }
    }
}