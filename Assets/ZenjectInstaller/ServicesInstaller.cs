using UnityEngine;
using Zenject;

namespace ButtonsAndDoors
{
    [CreateAssetMenu(fileName = "ServicesInstaller", menuName = "Zenject/ServicesInstaller")]
    public class ServicesInstaller : ScriptableObjectInstaller<ServicesInstaller>
    {

        public SceneData sceneData;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartUpEcs>().AsSingle().NonLazy();
            Container.Bind<SceneData>().FromInstance(sceneData).AsSingle().NonLazy();
          
        }
    }
}