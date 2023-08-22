using System;
using System.Collections.Generic;
using System.Reflection;
using GameCore.Pooling;
using GameCore.States;
using GameCore.States.Concrete;
using Startup.BootstrapStages;
using States.Abstraction;
using UnityEngine;
using Zenject;

namespace Startup
{
    public class Bootstrap: MonoBehaviour
    {
        [Inject] private DiContainer m_container;
        [Inject] private GameStateSystem m_gameStateSystem;
        [Inject] private Pool<BaseState> m_statesPool;
        
        private List<BaseLoadingStage> m_loadingStages = new(5);

        private void Start()
        {
            foreach (var type in Assembly.GetAssembly(typeof(BaseLoadingStage)).GetTypes())
            {
                if (!type.IsAbstract && type.IsClass)
                {
                    m_loadingStages.Add(m_container.Resolve(type) as BaseLoadingStage);
                }
            }
            
            StartGame();
        }

        private async void StartGame()
        {
            foreach (var stage in m_loadingStages)
            {
                await stage.Run();
            }
            
            m_gameStateSystem.SwitchTo(m_statesPool.Get<GameStartState>());
        }
    }
}
