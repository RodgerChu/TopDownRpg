using System;
using System.Reflection;
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
            var types = Assembly.GetAssembly(typeof(BaseProtoMetaLoader)).GetTypes();
            foreach (var type in types)
            {
                if (!type.IsAbstract && typeof(IProtoMetaLoader).IsAssignableFrom(type))
                {
                    var loader = Activator.CreateInstance(type) as BaseMetaLoader;
                    loader.Load(meta =>
                    {
                        var metaType = meta.GetType();
                        container.Bind(metaType).FromInstance(meta);
                    }, container);
                }
            }
        }
    }
}
