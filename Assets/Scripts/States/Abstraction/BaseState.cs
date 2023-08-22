using System;
using ResourcesManagement.Abstraction;
using UI;
using Zenject;

namespace States.Abstraction
{
    public abstract class BaseState
    {
        [Inject] protected BaseSceneLoader m_sceneLoader;
        [Inject] protected ViewsManager m_viewManager;

        public virtual void PrepareForActivation(Action<BaseState> onReady)
        {
            onReady(this);
        }
        public abstract void Activate();
        public abstract void Deactivate();
    }
}
