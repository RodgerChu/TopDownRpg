using System;
using GameCore.Fight.Character;
using UnityEngine;
using Utils;

namespace GameCore.Movement
{
    public interface ICharacterDestinationProvider
    {
        Vector2 GetDestination(ICharacter character);
    }
    
    public class SquadPositionsProvider : MonoBehaviour, ICharacterDestinationProvider
    {
        [Serializable]
        private struct PositionInfo
        {
            [SerializeField] public Transform transform;
            [HideInInspector] public ICharacter client;
        }

        [SerializeField]
        private PositionInfo[] m_points;

        public Vector2 GetDestination(ICharacter character)
        {
            ref var freePoint = ref m_points[0];
            for (var index = 0; index < m_points.Length; index++)
            {
                ref var point = ref m_points[index];
                if (point.client == null)
                {
                    freePoint = ref point;
                }
                else if (point.client == character)
                {
                    return point.transform.position.XY();
                }
            }

            if (freePoint.transform is not null)
            {
                freePoint.client = character;
                return freePoint.transform.position.XY();
            }

            var center = m_points[0].transform.position - m_points[^1].transform.position;
            return new Vector2(center.x, center.y);
        }

        public void ReleasePosition(ICharacter character)
        {
            for (var index = 0; index < m_points.Length; index++)
            {
                ref var point = ref m_points[index];
                if (point.client == character)
                {
                    point.client = null;
                }
            }
        }

    }
}
