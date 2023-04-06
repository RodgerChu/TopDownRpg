using GameCore.Movement;
using UnityEngine;
using Zenject;

public class BaseMovementController: MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    
    [Inject] private IMovementDestinationProvider m_movementDestinationProvider;
    [Inject] private CharacterController m_controller;

    public void Update()
    {
        var destination = m_movementDestinationProvider.GetDestination();
        m_controller.Move(destination * (m_moveSpeed * Time.deltaTime));
    }
}
