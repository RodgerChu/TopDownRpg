using System;
using System.Collections.Generic;
using GameCore.Fight.Character.Stats;
using ProtoBuf;

namespace Meta.Data
{
    [Serializable]
    [ProtoContract]
    public class GameCharacter
    {
        [ProtoMember(1)]
        public int id;
        [ProtoMember(2)]
        public RarityType rarity;
        [ProtoMember(3)]
        public string name;
        [ProtoMember(4)]
        public string prefab;
        [ProtoMember(5)]
        public List<int> skills = new List<int>();
        [ProtoMember(6)]
        public Dictionary<CharacterStatType, float> characterStats = new Dictionary<CharacterStatType, float>();
        [ProtoMember(7)]
        public CharacterClassType characterClass;
    }
    
    [Serializable]
    [ProtoContract]
    public class CharactersData
    {
        [ProtoMember(1)] 
        public List<GameCharacter> characters = new List<GameCharacter>();

        public const int maxCharactersInSquad = 4;
    }
}
