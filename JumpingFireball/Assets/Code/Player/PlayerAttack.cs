using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Pooling;

namespace Code.Players
{
    public class PlayerAttack : MonoBehaviour
    {
        public Transform BulletSpawnPoint;

        private Transform _transform;
        private Coroutine _changeScale;
        private ObjectPooling _objectPooling;

        private GameObject BulletBallObject;

        private float _scaleMyBall = 1f;
        private string _id = "BulletBall";

        public void Init(ObjectPooling objectPooling)
        {
            _transform = transform;
            _objectPooling = objectPooling;
        }

        public void OnFire()
        {
            CreateBulletBall();
            _changeScale = StartCoroutine(ChangeScale());
        }

        public void OffFire()
        {
            if (_changeScale != null) StopCoroutine(_changeScale);
        }

        private void CreateBulletBall()
        {
            BulletBallObject = _objectPooling.ObjectActivation(_id, BulletSpawnPoint.position);
        }
        private IEnumerator ChangeScale()
        {
            while (_scaleMyBall > 0)
            {
                yield return new WaitForFixedUpdate();
                _scaleMyBall -= 0.001f;
                _transform.localScale = new Vector3(_scaleMyBall, _scaleMyBall, _scaleMyBall);
            }
        }

    }
}

