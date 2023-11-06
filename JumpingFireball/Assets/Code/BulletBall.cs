using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Pooling;

public class BulletBall : MonoBehaviour
{
    public float MoveSpeed = 1;
    public Transform TransformTrail;

    private Transform _transform;
    private Rigidbody _rb;
    private ParticlesPooling _particlesPooling;

    private List<GameObject> _gameObjects = new List<GameObject>();


    private readonly string _explosionParticle = "Explosion";

    public void Init(ParticlesPooling particlesPooling)
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _particlesPooling = particlesPooling;

        _rb.velocity = new Vector3(0, 0, 0);
        _transform.localScale = new Vector3(0, 0, 0);
        TransformTrail.gameObject.SetActive(false);
        TransformTrail.parent = _transform;
        TransformTrail.localPosition = new Vector3(0, 0, 0);
        TransformTrail.gameObject.SetActive(true);
    }

    public void StartMove() => _rb.AddForce(Vector3.left * MoveSpeed, ForceMode.VelocityChange);
    public void UpdateScale(float myScale) => transform.localScale = new Vector3(myScale, myScale, myScale);


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy) _gameObjects.Add(other.gameObject);
        else Explosion();
    }

    private void OnTriggerExit(Collider other)
    {
        Explosion();
    }
    public void Explosion()
    {
        foreach (var item in _gameObjects)
        {
            Destroy(item);
        }
        _particlesPooling.PlayParticle(_explosionParticle, transform.position, Quaternion.identity, transform.localScale);
        _gameObjects.Clear();
        TransformTrail.parent = null;
        gameObject.SetActive(false);
    }


}
