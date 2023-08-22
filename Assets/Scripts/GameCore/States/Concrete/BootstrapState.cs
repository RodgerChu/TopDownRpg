using System;
using States.Abstraction;
using UI.View.Bootstrap;

namespace States.Concrete
{
    public class BootstrapState: BaseState
    {
        public override void PrepareForActivation(Action<BaseState> onReady)
        {
            base.PrepareForActivation((state) =>
            {
                m_viewManager.Show<BootstrapView>();
                onReady?.Invoke(state);
            });
        }

        public override void Activate()
        {
            
        }

        public override void Deactivate()
        {
        }
    }
}