using System.Collections.Generic;
using ProtoBuf;

namespace Models
{
    public struct PlayerItem
    {
        public int itemInstanceId;
        public int itemMetaId;
        public uint itemPower;
        public int equippedCharacterId;

        public bool usedByCharacter => equippedCharacterId != 0;
    }
    
    [ProtoContract]
    public class InventoryModel: BaseModel
    {
        [ProtoMember(1)] 
        private List<PlayerItem> m_playerItems = new List<PlayerItem>();

        public List<PlayerItem> GetAllItems() => m_playerItems;

        public void AddItem(int instanceId, int itemMetaId, uint power) => m_playerItems.Add(new PlayerItem
        {
            itemInstanceId = instanceId,
            itemMetaId = itemMetaId,
            itemPower = power
        });

        public void RemoveItem(int instanceId)
        {
            foreach (var playerItem in m_playerItems)
            {
                if (playerItem.itemInstanceId == instanceId)
                {
                    m_playerItems.Remove(playerItem);
                    return;
                }
            }
        }

        public void MarkItemAsUsedByCharacter(int instanceId, int characterId)
        {
            for (var index = 0; index < m_playerItems.Count; index++)
            {
                var playerItem = m_playerItems[index];
                if (playerItem.itemInstanceId == instanceId)
                {
                    playerItem.equippedCharacterId = characterId;
                    m_playerItems[index] = playerItem;
                    return;
                }
            }
        }
    }
}