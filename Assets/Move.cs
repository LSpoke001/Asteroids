using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform pointBullet;
    [SerializeField] private Button attackButton;
    

    private float speedBullet = 500f;

    private void OnEnable()
    {
        attackButton.onClick.AddListener(StartAttack);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            RotateShip();
        }
    }

    private void RotateShip()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(touch.position);

        Vector3 targetRotate = targetPosition - transform.position;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 0) * targetRotate;
        
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
            rotateSpeed * Time.deltaTime);
    }
    private void StartAttack()
    {
        Bullet newBullet = Instantiate(bulletPrefab, pointBullet.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * speedBullet);
    }
}
