using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidsSpawner : MonoBehaviour
{
    private Asteroid asteroidPrefab;
    public float spawnRate = 1.0f;
    public int spawnAmount = 1;

    private float spawnDistance = 12f;
    public float trajectoryVariance = 15f;

    public event UnityAction CrashedAsteroid;

    public void InitSpawner(Asteroid asteroid)
    {
        asteroidPrefab = asteroid;
    }
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {

            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * this.spawnDistance;

            spawnPoint += this.transform.position;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.Crashed += CrashAsteroid;
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            Vector2 trajectory = rotation * -spawnDirection;
            asteroid.SetTrajectory(trajectory);
        }
    }

    private void CrashAsteroid(Asteroid asteroid)
    {
        CrashedAsteroid?.Invoke();
        asteroid.Crashed -= CrashAsteroid;
    }
}
