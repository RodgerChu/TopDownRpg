namespace UI.View.Squad
{
    public class PlayerSquadView: BaseView
    {
        protected override void OnShow()
        {
            base.OnShow();
        }

        protected override void OnHide()
        {
            base.OnHide();
        }
        
        // UNITY EVENTS
        public void OnCloseButtonClickHandle()
        {
            viewSystem.Hide(this);
        }
    }
}