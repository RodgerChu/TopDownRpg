using System.Collections.Generic;
using GameCore.AI.Tags;
using GameCore.Fight.Character;
using UnityEngine;

namespace GameCore.Fight.EnemiesLocator
{
    public class EnemiesLocator : MonoBehaviour, IEnemiesLocator
    {
        private HashSet<ICharacter> m_enemiesInSight = new();

        public bool HasEnemiesInSight()
        {
            return m_enemiesInSight.Count != 0;
        }

        public bool EnemyInSight(ICharacter character)
        {
            return m_enemiesInSight.Contains(character);
        }

        public ICharacter GetNearestEnemy(ICharacter client)
        {
            var minDist = float.MaxValue;
            ICharacter nearestEnemy = null;
            var center = client.position;
            var clientPosition = new Vector2(center.x, center.y);
            foreach (var enemy in m_enemiesInSight)
            {
                var enemyCenter = client.position;
                var enemyPosition = new Vector2(enemyCenter.x, enemyCenter.y);
                var distBetween = Vector2.Distance(enemyPosition, clientPosition);
                if (distBetween < minDist)
                {
                    minDist = distBetween;
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<CharacterTag>(out var characterTag))
            {
                m_enemiesInSight.Add(characterTag.GetCharacter());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<CharacterTag>(out var characterTag))
            {
                m_enemiesInSight.Remove(characterTag.GetCharacter());
            }
        }

        public Vector2 GetDestination(ICharacter character)
        {
            return GetNearestEnemy(character).position;
        }
    }
}
