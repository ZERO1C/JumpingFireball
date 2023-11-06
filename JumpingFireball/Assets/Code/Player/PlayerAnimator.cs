using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Players
{
    public class PlayerAnimator : MonoBehaviour
    {
        private GameMediator _gameMediator;
        private Animator _animator;
        private readonly string _moveToFinish = "MoveToFinish";

        public void Init(GameMediator gameMediator)
        {
            _gameMediator = gameMediator;
            _animator = GetComponent<Animator>();
        }

        public void StartMoveToFinishAnim() => _animator.SetTrigger(_moveToFinish);
        public void EndMoveToFinishAnim()
        {
            _gameMediator.FinishPlayerAnim();
        }
    }
}

