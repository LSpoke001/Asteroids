using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShip : MonoBehaviour
{
    public int health = 5;
    [SerializeField] private CanvasGroup canvas;

    private void Start()
    {
        canvas.alpha = 0f;
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
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
            canvas.alpha = 1f;
        }
    }
}
