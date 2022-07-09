using UnityEngine;
using Zenject;

namespace ButtonsAndDoors
{
    [CreateAssetMenu(fileName = "ServicesInstaller", menuName = "Zenject/ServicesInstaller")]
    public class ServicesInstaller : ScriptableObjectInstaller<ServicesInstaller>
    {
        public SceneData sceneData;
        public PrefabData prefabData;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartUpEcs>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<FactoryMonoObject>().AsSingle().NonLazy();
            Container.Bind<SceneData>().FromInstance(sceneData).AsSingle().NonLazy();
            Container.Bind<PrefabData>().FromInstance(prefabData).AsSingle().NonLazy();
        }
    }
}