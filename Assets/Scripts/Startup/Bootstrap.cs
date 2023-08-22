using System;
using System.Collections.Generic;
using System.Reflection;
using Startup.BootstrapStages;
using UnityEngine;
using Zenject;

namespace Startup
{
    public class Bootstrap: MonoBehaviour
    {
        [Inject] private DiContainer m_container;
        
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
        }
    }
}
