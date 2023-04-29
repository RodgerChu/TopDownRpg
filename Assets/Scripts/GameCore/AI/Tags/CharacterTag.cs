using GameCore.Fight.Character;
using UnityEngine;

namespace GameCore.AI.Tags
{
    public class CharacterTag : MonoBehaviour
    {
        [SerializeField] private BaseCharacter m_character;

        public ICharacter GetCharacter() => m_character;
    }
}
