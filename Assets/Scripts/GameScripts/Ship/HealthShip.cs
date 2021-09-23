using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthShip : MonoBehaviour
{
    public int health = 5;
    public event UnityAction Died;
    public event UnityAction<int> HealthChanged;

    private ShipSound shipSound;

    private void Start()
    {
        HealthChanged?.Invoke(health);
        shipSound = GetComponentInChildren<ShipSound>();
    }

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
        HealthChanged?.Invoke(health);
        shipSound.Play("Hit");
        if (health <= 0)
        {
            DiePlayer();
            shipSound.Play("Death");
        }
    }
    private void DiePlayer()
    {
        Died?.Invoke();
    }
}
