using System.Collections.Generic;
using GameCore.Inventory.Abstractions;
using GameCore.Pooling;
using UnityEngine;
using Zenject;

namespace GameCore.Inventory.Concrete
{
    public class InventoryPresenter: MonoBehaviour, IInventoryPresenter
    {
        [SerializeField] private InventoryCell m_cellPrefab;
        [SerializeField] private Transform m_cellsParent;

        private List<InventoryCell> m_shownCells = new();

        [Inject] private MonoPool<InventoryCell> m_cellsPool;

        public void ShowItems(IEnumerable<IItem> items)
        {
            foreach (var cell in m_shownCells)
            {
                m_cellsPool.Return(cell);
            }

            foreach (var item in items)
            {
                var cell = m_cellsPool.Get(m_cellPrefab);
                cell.SetItem(item);
                cell.transform.SetParent(m_cellsParent);
                cell.gameObject.SetActive(true);
            }
        }
    }
}