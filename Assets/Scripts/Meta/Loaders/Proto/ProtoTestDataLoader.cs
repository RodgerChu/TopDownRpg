using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Meta.Data;
using Meta.Loaders.Json;
using ProtoBuf;
using Unity.Loading;
using UnityEngine;
using Zenject;

namespace Meta.Loaders
{
    public class ProtoTestDataLoader : BaseProtoMetaLoader
    {
        public override UniTask<object> Load(Action<object, DiContainer> callback, DiContainer container)
        {
            var utc = new UniTaskCompletionSource<object>();
            
            var handle = Resources.LoadAsync<TextAsset>(resourcesMetaPath + "/" + nameof(TestProtoMetaData));
            handle.completed += _ =>
            {
                using var memStream = new MemoryStream((handle.asset as TextAsset).bytes);
                var data = Serializer.Deserialize<TestProtoMetaData>(memStream);
                callback(data, container);
                utc.TrySetResult(data);
            };
            
            return utc.Task;
        }
    }
}
