using System;
using Meta.Loaders;
using Meta.Loaders.Json;
using ProtoBuf;

namespace Meta.Data
{
    [Serializable]
    [ProtoContract]
    public class TestProtoMetaData: IProtoMeta, IJsonMeta
    {
        [ProtoMember(1)]
        public int someData;
        [ProtoMember(2)]
        public string someStringData;
    }
}
