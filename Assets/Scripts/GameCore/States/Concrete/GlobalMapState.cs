using System;
using ResourcesManagement.Concrete;
using States.Abstraction;

namespace GameCore.States.Concrete
{
    public class GlobalMapState: BaseState
    {
        public override void PrepareForActivation(Action<BaseState> onReady)
        {
            m_sceneLoader.LoadScene(SceneNamesConsts.GlobalMapSceneName, () => base.PrepareForActivation(onReady));
        }

        public override void Activate()
        {
            
        }

        public override void Deactivate()
        {
            
        }
    }
}
