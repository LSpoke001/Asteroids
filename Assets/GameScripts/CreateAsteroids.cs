using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateAsteroids : MonoBehaviour
{
    public AsteroidsSpawner _asteroidsSpawner;
    public Asteroid _asteroid;

    public event UnityAction<int> CountChanged;
    private int count = 0;

    private void Start()
    {
        var spawner = Instantiate(_asteroidsSpawner, transform);
        spawner.InitSpawner(_asteroid);
        spawner.CrashedAsteroid += ChangeCount;
        CountChanged?.Invoke(count);
    }

    private void ChangeCount()
    {
        count++;
        CountChanged?.Invoke(count);
    }
}
