using System;
using ResourcesManagement.Concrete;
using States.Abstraction;

namespace GameCore.States.Concrete
{
    public class TownState: BaseState
    {
        public override void PrepareForActivation(Action<BaseState> onReady)
        {
            m_sceneLoader.LoadScene(SceneNamesConsts.TownSceneName, () => base.PrepareForActivation(onReady));
        }

        public override void Activate()
        {
            
        }

        public override void Deactivate()
        {
        }
    }
}
