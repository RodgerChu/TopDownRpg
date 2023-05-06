using GameCore.Debug;
using Zenject;

public class LoggerBinder : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ConsoleLogger>().To<ConsoleLogger>().AsSingle();
    }
}