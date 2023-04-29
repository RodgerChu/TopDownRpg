using ResourcesManagement.Abstraction;
using ResourcesManagement.Concrete;
using Zenject;

public class ResourcesManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BaseSceneLoader>().FromInstance(new UnityResourcesSceneLoader()).AsSingle();
    }
}