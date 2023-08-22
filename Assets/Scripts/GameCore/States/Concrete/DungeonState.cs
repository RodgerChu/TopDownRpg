using System;
using ResourcesManagement.Concrete;
using States.Abstraction;

namespace States.Concrete
{
    public class DungeonState: BaseState
    {
        public override void PrepareForActivation(Action<BaseState> onReady)
        {
            m_sceneLoader.LoadScene(SceneNamesConsts.DungeonSceneName, () => base.PrepareForActivation(onReady));
        }

        public override void Activate()
        {
            
        }

        public override void Deactivate()
        {
        }
    }
}
