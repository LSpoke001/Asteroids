using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*private Rigidbody2D _rigidbody2D;
    private float speed = 500f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * speed);
    }*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
