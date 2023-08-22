using System;
using GameCore.AI.Tags;
using GameCore.Fight.Character;
using UI.View;
using UI.View.Notification;
using UnityEngine;
using Utils;
using Zenject;

namespace UI.EntryPoint
{
    public abstract class BaseUITriggerZone<TView, TNotificator>: MonoBehaviour 
        where TView: BaseView, new() 
        where TNotificator: InteractableBuildingNotificator, new()
    {
        [SerializeField] private Transform m_notificatorPositionOrigin;
        
        [Inject] private ViewsManager m_viewsManager;
        [Inject] private Canvas m_canvas;

        private RectTransform m_canvasTransform;
        private TNotificator m_shownView;
        private Action m_onNotificatorClick;
        
        private void Awake()
        {
            m_canvasTransform = ((RectTransform)m_canvas.transform);
            m_onNotificatorClick = OnNotificatorClick;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (m_shownView is not null)
            {
                return;
            }
            
            if (col.gameObject.TryGetComponent(out CharacterTag _))
            {
                m_shownView = m_viewsManager.Show<TNotificator>();
                m_shownView.onNotificatorClick += m_onNotificatorClick;
                var globalPosition = m_notificatorPositionOrigin.position.XY();
                var viewportPosition = Camera.main.WorldToViewportPoint(globalPosition);
                var sizeDelta = m_canvasTransform.sizeDelta;
                var proportionalPosition = new Vector2(viewportPosition.x * sizeDelta.x, viewportPosition.y * sizeDelta.y);
                m_shownView.SetPosition(proportionalPosition);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (m_shownView is null)
            {
                return;
            }
            
            if (col.gameObject.TryGetComponent(out CharacterTag _))
            {
                m_shownView.onNotificatorClick -= m_onNotificatorClick;
                m_viewsManager.Hide(m_shownView);
                m_shownView = null;
            }
        }

        private void OnNotificatorClick()
        {
            m_viewsManager.Show<TView>();
        }
    }
}
