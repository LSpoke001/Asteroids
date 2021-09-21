using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthShip : MonoBehaviour
{
    public int health = 5;
    public event UnityAction Died;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Asteroid>())
        {
            HealthChange();
        }
    }

    private void HealthChange()
    {
        health--;
        Debug.Log(health);
        if (health <= 0)
        {
            DiePlayer();
        }
    }
    private void DiePlayer()
    {
        Died?.Invoke();
    }
}
