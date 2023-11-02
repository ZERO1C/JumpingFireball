using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Players;
using Zenject;

namespace Code.UI
{

    public class UIController : MonoBehaviour
    {
        private Player _player;
        [Inject]
        public void Init(Player player)
        {
            _player = player;
        }
        public void OnFireButtonDown(bool buttonDown)
        {
            _player.OnFire(buttonDown);
        }

    }
}

