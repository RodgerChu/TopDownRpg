using GameCore.Pooling;
using States;
using States.Abstraction;
using States.Concrete;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ToCityButton : MonoBehaviour
    {
        [Inject] private StatesManager m_statesManager;
        [Inject] private Pool<BaseState> m_statesPool;

        public void OnButtonClick()
        {
            m_statesManager.SwitchTo(m_statesPool.Get<TownState>());
        }
    }
}
