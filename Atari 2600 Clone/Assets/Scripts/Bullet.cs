using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D bulletRigidbody;
    [Header("Settings")]
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float projectileLifetime = 3f;

    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        bulletRigidbody.velocity = transform.up * bulletSpeed;
        Destroy(gameObject, projectileLifetime);
    }

}
