using GameCore.Inventory.Abstractions;
using GameCore.Pooling;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCore.Inventory.Concrete
{
    public class InventoryCell: PoolableMonoBehaviour
    {
        [SerializeField] private Image m_image;

        [Inject] private IInventoryIconProvider m_iconProvider;

        private IItem m_item;
        
        public void SetItem(IItem item)
        {
            m_image.sprite = m_iconProvider.GetIcon(item);
        }

        public override void OnMovedToPool()
        {
            m_item = null;
            m_image.sprite = null;
        }
    }
}