using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.UI;
using Zenject;
using System;
using UnityEngine.SceneManagement;

public class GameMediator : MonoBehaviour
{
    [HideInInspector] public Road Road;

    public event Action WinGameEvent;
    public event Action LostGameEvent;

    private FinishDetector _finishDetector;
    private UIMediator _uIMediator;
    private bool _playerDontTapToScreen;
    private bool _finishPlayerAnim;
    private bool _finishGame = true;

    [Inject]
    public void Init(UIMediator uIMediator)
    {
        BindRoad();
        BindFinishDetector();
        Road.Init();
        _finishDetector.Init(this);
        _uIMediator = uIMediator;
        uIMediator.TapToScreen += PlayerTapToScreen;
    }
    public void BindRoad() => Road = gameObject.GetComponentInChildren<Road>();
    public void BindFinishDetector() => _finishDetector = gameObject.GetComponentInChildren<FinishDetector>();


    public void PlayerTapToScreen(bool playerDontTapToScreen) => _playerDontTapToScreen = playerDontTapToScreen;
    public void FinishPlayerAnim() => _finishPlayerAnim = true;


    public void WinGame()
    {
        if (_finishGame)
        {
            StartCoroutine(WinGameCurotine());
            _finishGame = false;
        }        
    }

    private IEnumerator WinGameCurotine()
    {
        yield return new WaitUntil(() => !_playerDontTapToScreen);
        _uIMediator.ChangeState(UIState.NoTarget);
        yield return new WaitForSeconds(1);
        WinGameEvent.Invoke();
        yield return new WaitUntil(() => _finishPlayerAnim);
        _uIMediator.OpenWinScreen();
    }

    public void LostGame()
    {
        if(_finishGame)
        {
            LostGameEvent.Invoke();
            _finishGame = false;
        }
    }

    public void SceneReload() => SceneManager.LoadScene(0);

}
