using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Pooling;
using Zenject;

namespace Code.Players
{
    public class Player : MonoBehaviour
    {
        private PlayerAttack _playerAttack;
        private PlayerMoving _playerMoving;

        [Inject]
        public void Init(ObjectPooling objectPooling)
        {
            BindPlayerAttack();
            BindPlayerMoving();
            _playerAttack.Init(objectPooling);
        }
        public void BindPlayerAttack()
        {
            _playerAttack = GetComponent<PlayerAttack>();
        }
        public void BindPlayerMoving()
        {
            _playerMoving = GetComponent<PlayerMoving>();
        }

        public void OnFire(bool onFire)
        {
            if (onFire) _playerAttack.OnFire();
            else _playerAttack.OffFire();
        }
    }
}


