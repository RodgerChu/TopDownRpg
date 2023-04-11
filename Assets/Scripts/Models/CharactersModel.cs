using System.Collections.Generic;
using GameCore.Debug;
using Meta.Data;
using ProtoBuf;
using Zenject;

namespace Models
{
    public struct PlayerCharacterInfo
    {
        public int id;
        public int level;
        public int totalExperience;
    }
    
    [ProtoContract]
    public class CharactersModel: BaseModel
    {
        [ProtoMember(1)] 
        private List<PlayerCharacterInfo> m_unlockedCharactersInfo = new List<PlayerCharacterInfo>();
        [ProtoMember(2)]
        private List<int> m_charactersInSquad = new List<int>(CharactersData.maxCharactersInSquad);

        [Inject] private ILogger m_logger;

        public List<int> GetCharactersInSquad() => m_charactersInSquad;
        public List<PlayerCharacterInfo> GetUnlockedCharacters() => m_unlockedCharactersInfo;

        private bool CheckCanAddCharacterToSquad()
        {
            return m_charactersInSquad.Count < CharactersData.maxCharactersInSquad;
        }
        
        public void SetCharacterToSquad(int characterId)
        {
            if (!CheckCanAddCharacterToSquad())
            {
                m_logger.LogError("[CHARACTERS] can't add character to squad: max squadmates reached");
                return;
            }
            
            m_charactersInSquad.Add(characterId);
        }

        public void RemoveCharacterFromSquad(int characterId)
        {
            m_charactersInSquad.Remove(characterId);
        }

        public void SetCharacterUnlocked(int characterId)
        {
            foreach (var characterInfo in m_unlockedCharactersInfo)
            {
                if (characterInfo.id == characterId)
                {
                    m_logger.LogError($"[CHARACTERS] character with id {characterId.ToString()} already unlocked");
                    return;
                }
            }
            
            m_unlockedCharactersInfo.Add(new PlayerCharacterInfo
            {
                id = characterId,
                level = 1
            });
        }
    }
}
