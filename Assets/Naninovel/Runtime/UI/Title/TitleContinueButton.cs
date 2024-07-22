// Copyright 2023 ReWaffle LLC. All rights reserved.


namespace Naninovel.UI
{
    public class TitleContinueButton : ScriptableButton
    {
        private IStateManager stateManager;
        private IUIManager uiManager;

        protected override void Awake ()
        {
            base.Awake();

            stateManager = Engine.GetService<IStateManager>();
            uiManager = Engine.GetService<IUIManager>();
        }

        protected override void Start ()
        {
            base.Start();

            ControlInteractability(default);
        }

        protected override void OnEnable ()
        {
            base.OnEnable();

            stateManager.GameSlotManager.OnSaved += ControlInteractability;
            stateManager.GameSlotManager.OnDeleted += ControlInteractability;
        }

        protected override void OnDisable ()
        {
            base.OnDisable();

            stateManager.GameSlotManager.OnSaved -= ControlInteractability;
            stateManager.GameSlotManager.OnDeleted -= ControlInteractability;
        }

        protected override void OnButtonClick ()
        {
            var saveLoadUI = uiManager.GetUI<ITitleUI>();
            var states = Engine.GetService<IStateManager>();

            states.QuickLoadAsync();
            saveLoadUI.Hide();
        }

        private void ControlInteractability (string _) => UIComponent.interactable = stateManager.AnyGameSaveExists;
    }
}
