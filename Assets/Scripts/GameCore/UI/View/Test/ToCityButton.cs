using GameCore.Pooling;
using GameCore.Systems.GameState;
using States;
using States.Abstraction;
using States.Concrete;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ToCityButton : MonoBehaviour
    {
        [Inject] private GameStateSystem m_gameStateSystem;
        [Inject] private Pool<BaseState> m_statesPool;

        public void OnButtonClick()
        {
            m_gameStateSystem.SwitchTo(m_statesPool.Get<TownState>());
        }
    }
}
