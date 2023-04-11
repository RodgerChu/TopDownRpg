using System.Collections.Generic;
using GameCore.Inventory.Abstractions;

namespace GameCore.Inventory
{
    public interface IInventoryPresenter
    {
        void ShowItems(IEnumerable<IItem> items);
    }
}