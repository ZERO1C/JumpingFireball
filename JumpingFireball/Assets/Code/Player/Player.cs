using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Pooling;
using Code.UI;
using Zenject;

namespace Code.Players
{
    public class Player : MonoBehaviour
    {
        private PlayerAttack _playerAttack;
        private PlayerAnimator _playerAnimator;

        [Inject]
        public void Init(ObjectPooling objectPooling, GameMediator gameMediator, UIMediator uIMediator, ParticlesPooling particlesPooling)
        {
            BindPlayerAttack();
            BindPlayerAnimator();
            _playerAttack.Init(objectPooling, gameMediator.Road, gameMediator, particlesPooling);
            _playerAnimator.Init(gameMediator);
            uIMediator.TapToScreen += OnFire;
            gameMediator.WinGameEvent += StartMoveToFinish;
        }
        public void BindPlayerAttack() => _playerAttack = GetComponent<PlayerAttack>();
        public void BindPlayerAnimator() => _playerAnimator = GetComponent<PlayerAnimator>();


        public void OnFire(bool onFire)
        {
            if (onFire) _playerAttack.OnFire();
            else _playerAttack.OffFire();
        }
        public void StartMoveToFinish() => _playerAnimator.StartMoveToFinishAnim();
    }
}


