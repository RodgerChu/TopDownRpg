using System;
using System.Reflection;
using Meta.Loaders.Json;
using Zenject;

namespace Startup.GlobalBinders
{
    public class JsonMetaBinder : BaseMetaBinder
    {
        public override void InstallBindings(DiContainer container)
        {
            var types = Assembly.GetAssembly(typeof(IJsonMetaLoader)).GetTypes();
            foreach (var type in types)
            {
                if (!type.IsAbstract && typeof(IJsonMetaLoader).IsAssignableFrom(type))
                {
                    var loader = Activator.CreateInstance(type) as BaseMetaLoader;
                    loader.Load(meta =>
                    {
                        container.Bind(meta.GetType()).FromInstance(meta);
                    });
                }
            }
        }
    }
}
