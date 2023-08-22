using GameCore.Pooling;
using GameCore.States;
using GameCore.States.Concrete;
using States;
using States.Abstraction;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ToDungeonButton : MonoBehaviour
    {
        [Inject] private GameStateSystem m_gameStateSystem;
        [Inject] private Pool<BaseState> m_statesPool;

        public void OnButtonClick()
        {
            m_gameStateSystem.SwitchTo(m_statesPool.Get<DungeonState>());
        }
    }
}