using System;
using System.IO;
using Meta.Data;
using ProtoBuf;
using UnityEngine;

namespace Meta.Loaders
{
    public class ProtoTestDataLoader : BaseProtoMetaLoader
    {
        public override void Load(Action<object> onLoad)
        {
            var handle = Resources.LoadAsync<TextAsset>(resourcesMetaPath + "/" + nameof(TestProtoMetaData));
            handle.completed += _ =>
            {
                using var memStream = new MemoryStream((handle.asset as TextAsset).bytes);
                onLoad(Serializer.Deserialize<TestProtoMetaData>(memStream));
            };
        }
    }
}
