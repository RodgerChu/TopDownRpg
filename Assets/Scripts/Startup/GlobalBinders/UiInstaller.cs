using GameCore.Pooling;
using UI;
using UI.View;
using UI.View.Collection;
using UnityEngine;
using Zenject;

namespace Startup.GlobalBinders
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private Canvas m_canvas;
        [SerializeField] private ViewCollection m_viewCollection;
        
        public override void InstallBindings()
        {
            Container.Bind<Canvas>().FromInstance(m_canvas).AsSingle();
            Container.Bind<MonoPool<BaseView>>().To<MonoPool<BaseView>>().AsSingle();
            Container.Bind<ViewCollection>().FromInstance(m_viewCollection).AsSingle();
            Container.Bind<ViewsManager>().To<ViewsManager>().AsSingle();
        }
    }
}
