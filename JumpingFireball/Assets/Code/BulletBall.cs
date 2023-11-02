using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBall : MonoBehaviour
{
    public float MoveSpeed = 1;
    private Rigidbody _rb;
    public void Init()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void UpdateScale(float myScale)
    {
        transform.localScale = new Vector3(myScale, myScale, myScale);
    }
    public void StartMove()
    {
        _rb.AddForce(Vector3.left * MoveSpeed, ForceMode.VelocityChange);
    }

}
