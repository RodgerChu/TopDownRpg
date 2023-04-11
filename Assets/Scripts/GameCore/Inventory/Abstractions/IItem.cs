using System.Collections.Generic;
using GameCore.Fight.Character.Stats;

namespace GameCore.Inventory.Abstractions
{
    public interface IItem
    {
        public string icon { get; }
        public string name { get; }
        public string description { get; }
        
        public List<CharacterClassType> suitableClasses { get; }
        public List<ItemStat> itemStats { get; }
    }
}
