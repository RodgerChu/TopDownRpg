using System.Collections.Generic;
using GameCore.Fight.Character;
using UnityEngine;

namespace GameCore.Fight.EnemiesLocator
{
    public class BaseEnemiesLocator : MonoBehaviour, IEnemiesLocator
    {
        private List<ICharacter> m_enemiesInSight = new();

        public bool HasEnemiesInSight()
        {
            return m_enemiesInSight.Count != 0;
        }

        public ICharacter GetNearestEnemy(ICharacter client)
        {
            var minDist = float.MaxValue;
            ICharacter nearestEnemy = null;
            var center = client.characterController.center;
            var clientPosition = new Vector2(center.x, center.y);
            foreach (var enemy in m_enemiesInSight)
            {
                var enemyCenter = client.characterController.center;
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
    }
}
