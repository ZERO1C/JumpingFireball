using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    private GameMediator _gameMediator;
    private int _numStartEnemy;
    private int _numMinusEnemy;

    internal void Init(GameMediator gameMediator)
    {
        _gameMediator = gameMediator;
    }

    private void OnTriggerEnter(Collider other)
    {
        _numStartEnemy++;
        other.GetComponent<Enemy>().BindFinishDetector(this);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Enemy>().UnBindFinishDetector();
        MinusObject();
    }

    public void MinusObject()
    {
        _numMinusEnemy++;
        if (_numStartEnemy == _numMinusEnemy) _gameMediator.WinGame();

    }




}
