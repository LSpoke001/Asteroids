using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate = 1.0f;
    public int spawnAmount = 1;

    private float spawnDistance = 12f;
    public float trajectoryVariance = 15f;

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
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            Vector2 trajectory = rotation * -spawnDirection;
            asteroid.SetTrajectory(trajectory);
        }
    }
}
