using GameCore.Inventory.Abstractions;
using UnityEngine;

namespace GameCore.Inventory.Concrete
{
    public class ResourcesIconProvider: IInventoryIconProvider
    {
        public Sprite GetIcon(IItem item)
        {
            return Resources.Load<Sprite>("Icons/Items/" + item.icon);
        }
    }
}