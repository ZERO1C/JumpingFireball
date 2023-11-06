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
        private BulletBall _bulletBall;
        private Road _road;
        private GameMediator _gameMediator;
        private ParticlesPooling _particlesPooling;

        private GameObject BulletBallObject;

        private float _scaleMyBall = 1f;
        private float _scaleBulletBall = 0f;
        private readonly string _id = "BulletBall";

        public void Init(ObjectPooling objectPooling, Road road, GameMediator gameMediator, ParticlesPooling particlesPooling)
        {
            _transform = transform;
            _objectPooling = objectPooling;
            _road = road;
            _gameMediator = gameMediator;
            _particlesPooling = particlesPooling;
        }

        public void OnFire()
        {
            CreateBulletBall();
            _changeScale = StartCoroutine(ChangeScale());
        }

        public void OffFire()
        {
            if (_changeScale != null) StopCoroutine(_changeScale);
            _bulletBall.StartMove();
            _scaleBulletBall = 0;
        }

        private void CreateBulletBall()
        {
            BulletBallObject = _objectPooling.ObjectActivation(_id, BulletSpawnPoint.position);
            _bulletBall = BulletBallObject.GetComponent<BulletBall>();
            _bulletBall.Init(_particlesPooling);
        }
        private IEnumerator ChangeScale()
        {
            while (_scaleMyBall > 0.1f)
            {
                yield return new WaitForFixedUpdate();
                _scaleMyBall -= 0.003f;
                _scaleBulletBall += 0.003f * 10;
                _transform.localScale = new Vector3(_scaleMyBall, _scaleMyBall, _scaleMyBall);
                _bulletBall.UpdateScale(_scaleBulletBall);
                _road.NewScaleRoad(_scaleMyBall);
            }
            _road.NewScaleRoad(_scaleMyBall);
            _gameMediator.LostGame();
        }

    }
}

