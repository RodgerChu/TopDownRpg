using System;
using ResourcesManagement.Abstraction;
using Zenject;

namespace States.Abstraction
{
    public abstract class BaseState
    {
        [Inject] protected BaseSceneLoader m_sceneLoader;

        public virtual void PrepareForActivation(Action<BaseState> onReady)
        {
            onReady(this);
        }
        public abstract void Activate();
        public abstract void Deactivate();
    }
}
