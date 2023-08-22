using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Meta.Loaders;
using Meta.Loaders.Json;
using Zenject;

namespace Startup.GlobalBinders
{
    public abstract class BaseMetaBinder
    {
        public abstract void InstallBindings(DiContainer container);
    }
    
    public class ProtoMetaBinder : BaseMetaBinder
    {
        public override void InstallBindings(DiContainer container)
        {
            
        }
    }
}
