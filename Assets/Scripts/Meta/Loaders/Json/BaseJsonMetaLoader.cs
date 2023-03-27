using System;

namespace Meta.Loaders.Json
{
    public interface IJsonMeta { }
    public interface IJsonMetaLoader { }

    public abstract class BaseMetaLoader
    {
        public abstract void Load(Action<object> callback);
    }
    
    public abstract class BaseJsonMetaLoader: BaseMetaLoader, IJsonMetaLoader
    {
        public const string resourcesMetaPath = "DB/JsonsMeta";
    }
}
