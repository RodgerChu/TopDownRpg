using System;
using System.Collections.Generic;
using Meta.Loaders;
using Meta.Loaders.Json;
using ProtoBuf;

namespace Meta.Data
{
    [Serializable]
    [ProtoContract]
    public class SkillMetaData
    {
        [ProtoMember(1)]
        public int id;
        [ProtoMember(2)]
        public string projectilePrefab;
        [ProtoMember(3)]
        public string movementType;
        [ProtoMember(4)]
        public string[] movementEffects;
        [ProtoMember(5)]
        public string[] hitEffects;
        [ProtoMember(6)]
        public float range;
        [ProtoMember(7)]
        public float cooldown;
        [ProtoMember(8)] 
        public string projectileFireLogic;
    }

    [Serializable]
    [ProtoContract]
    public class SkillMetaDataContainer : IProtoMeta, IJsonMeta
    {
        [ProtoMember(1)]
        public List<SkillMetaData> skills = new List<SkillMetaData>();
    }
}
