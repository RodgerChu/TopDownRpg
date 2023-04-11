using System;
using System.Collections.Generic;
using Meta.Loaders;
using Meta.Loaders.Json;
using ProtoBuf;

namespace Meta.Data
{
    [Serializable]
    [ProtoContract]
    public struct LevelInfo
    {
        [ProtoMember(1)]
        public int expToNextLevel;
    }
    
    [Serializable]
    [ProtoContract]
    public class ExperienceData: IJsonMeta, IProtoMeta
    {
        [ProtoMember(1)]
        public List<LevelInfo> levels = new List<LevelInfo>();
    }
}
