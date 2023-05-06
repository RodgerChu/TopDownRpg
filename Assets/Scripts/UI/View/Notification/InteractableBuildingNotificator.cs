using System;
using UI.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Notification
{
    public class InteractableBuildingNotificator: Base3dView<InteractableBuildingNotificationController>
    {
        public event Action onNotificatorClick;
        
        [SerializeField] private Button m_notificatorButton;
        
        
        // UNITY EVENTS
        public void OnNotificatorButtonClick()
        {
            onNotificatorClick?.Invoke();
        }
    }
}
