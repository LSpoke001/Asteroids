using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthShip _Ship;
    public GameObject _heart;

    private List<GameObject> hearts = new List<GameObject>();

    private void OnEnable()
    {
        _Ship.HealthChanged += HealthChange;
    }

    private void OnDisable()
    {
        _Ship.HealthChanged -= HealthChange;
    }

    private void HealthChange(int value)
    {
        if (hearts.Count < value)
        {
            CreateHearts(value);
        }else if (hearts.Count > value)
        {
            Destroy(hearts[hearts.Count-1]);
            hearts.RemoveAt(hearts.Count-1);
        }
    }

    private void CreateHearts(int value)
    {
        for (int i = 0; i < value; i++)
        {
            var newHeart = Instantiate(_heart, transform);
            hearts.Add(newHeart);
        }
    }
}
