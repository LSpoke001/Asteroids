using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{ public Sprite[] sprites;

    public float size = 1f;
    public float maxSize = 1.5f;
    public float minSize = 0.5f;
    public float movementSpeed = 50.0f;
    private float maxLifetime = 15f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        transform.localScale = Vector3.one * size;

        _rigidbody2D.mass = size;
    }
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * this.movementSpeed);
        Destroy(gameObject, maxLifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() || collision.gameObject.GetComponent<Move>() )
        {
            if ((this.size * 0.5f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }

            //FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }
    private Asteroid CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        
        Asteroid half = Instantiate(this, position, transform.rotation);
        half.size = this.size * 0.5f;
        
        half.SetTrajectory(Random.insideUnitCircle.normalized);

        return half;
    }
}
