using System;
using System.Collections.Generic;
using Meta.Loaders;
using Meta.Loaders.Json;
using ProtoBuf;
using UnityEngine;

namespace Meta.Data
{
    public enum RarityType
    {
        Common,
        Rare,
        Legendary,
        Epic
    }
    
    [Serializable]
    [ProtoContract]
    public struct Rarity
    {
        [ProtoMember(1)]
        public RarityType rarityType; 
        [ProtoMember(2)]
        public Color32 color;
    }
    
    [Serializable]
    [ProtoContract]
    public class RaritiesData: IProtoMeta, IJsonMeta
    {
        [ProtoMember(1)]
        public List<Rarity> rarities = new List<Rarity>();
    }
}