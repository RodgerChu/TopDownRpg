using System;
using System.Collections.Generic;
using GameCore.Fight.Character.Stats;
using GameCore.Inventory;
using GameCore.Inventory.Abstractions;
using Meta.Loaders;
using Meta.Loaders.Json;
using ProtoBuf;

namespace Meta.Data
{
    [Serializable]
    [ProtoContract]
    public class EquipmentItem: IItem
    {
        [ProtoMember(1)] 
        public string icon { get; private set; }
        [ProtoMember(2)] 
        public string name { get; private set; }
        [ProtoMember(3)] 
        public string description { get; private set; }
        [ProtoMember(4)] 
        public List<CharacterClassType> suitableClasses { get; private set; }
        [ProtoMember(5)] 
        public List<ItemStat> itemStats { get; private set; }
        [ProtoMember(6)]
        public int id;
    }

    [Serializable]
    [ProtoContract]
    public class EquipmentItemsData: IJsonMeta, IProtoMeta
    {
        [ProtoMember(1)] 
        public List<EquipmentItem> equipmentItems = new List<EquipmentItem>();
    }
}
