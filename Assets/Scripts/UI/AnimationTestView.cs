using System;
using GameCore.Animations;
using UnityEngine;

namespace UI
{
    public class AnimationTestView : MonoBehaviour
    {
        [SerializeField] private CharacterAnimationController m_animationController;

        public void OnButtonClickHandler(int animationType)
        {
            try
            {
                m_animationController.PlayAnimation((AnimationType) animationType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
