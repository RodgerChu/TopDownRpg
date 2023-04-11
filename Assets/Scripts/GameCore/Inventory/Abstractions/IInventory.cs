using System.Collections.Generic;
using GameCore.Inventory.Abstractions;

namespace GameCore.Inventory
{
    public interface IInventory
    {
        public List<IItem> items { get; }
    }
}