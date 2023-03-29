using GameCore.Input;
using GameCore.Movement;
using UnityEngine;
using Zenject;

namespace GameCore.Zenject
{
    public class PlayerMovementControllerInstaller : MonoInstaller
    {
        [SerializeField] private BaseMovementController m_movementController;
        [SerializeField] private CharacterController m_controller;
        
        public override void InstallBindings()
        {
            Container.Bind<IMovementInput>().FromInstance(new KeyboardMovementInput()).AsSingle().NonLazy();
            Container.Bind<Transform>().FromInstance(transform).AsSingle();
            Container.Bind<BaseMovementController>().FromInstance(m_movementController).AsSingle();
            Container.Bind<CharacterController>().FromInstance(m_controller).AsSingle();
            
            var destinationInput = Container.Instantiate<MovementDestinationFromInput>();
            Container.Bind<IMovementDestinationProvider>().FromInstance(destinationInput).AsSingle();
        }
    }
}