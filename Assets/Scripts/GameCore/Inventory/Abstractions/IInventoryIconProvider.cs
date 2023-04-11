using GameCore.Inventory.Abstractions;
using UnityEngine;

namespace GameCore.Inventory
{
    public interface IInventoryIconProvider
    {
        Sprite GetIcon(IItem item);
    }
}