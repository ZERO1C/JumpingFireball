using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Players;
using Zenject;
using System;
using UnityEngine.UI;

namespace Code.UI
{

    public class UIMediator : MonoBehaviour
    {
        public event Action<bool> TapToScreen;
        private UIState uIState = UIState.Target;

        [Header("Win Elements")]  public GameObject WinPanel;
        public Button NextLevel;

        [Header("Lose Elements")] public GameObject LostPanel;
        public Button Restart;



        [Inject]
        public void Init(GameMediator gameMediator)
        {
            gameMediator.LostGameEvent += OpenLostScreen;
            NextLevel.onClick.AddListener(gameMediator.SceneReload);
            Restart.onClick.AddListener(gameMediator.SceneReload);

        }

        public void ChangeState(UIState newState) => uIState = newState;
        public void OnFireButtonDown(bool buttonDown)
        {
            switch (uIState)
            {
                case UIState.Target:
                    TapToScreen.Invoke(buttonDown);
                    break;
                case UIState.NoTarget:
                    break;
            }
        }
        public void OpenWinScreen() => WinPanel.SetActive(true);
        public void OpenLostScreen()
        {
            OnFireButtonDown(false);
            ChangeState(UIState.NoTarget);
            LostPanel.SetActive(true);
        }
    }
}

