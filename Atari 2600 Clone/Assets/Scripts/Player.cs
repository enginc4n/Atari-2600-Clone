using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float paddingHorizontal;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float attackRate = 2f;

    Animator animator;

    Shooting shooting;
    bool isAttacking;

    float nextAttackTime = 0;

    Vector2 moveInput, playerMovement;
    Vector2 minBounds, maxBounds;
    bool isDead;
    void Awake()
    {
        animator = GetComponent<Animator>();
        shooting = GetComponent<Shooting>();
    }
    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
        FlipSprite();
        FireProjectile();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Move()
    {
        playerMovement = moveInput * moveSpeed * Time.deltaTime;

        Vector2 playerBoundry;
        playerBoundry.x = Mathf.Clamp(transform.position.x + playerMovement.x, minBounds.x + paddingHorizontal, maxBounds.x - paddingHorizontal);
        playerBoundry.y = Mathf.Clamp(transform.position.y + playerMovement.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = playerBoundry;
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;

        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void FlipSprite()
    {
        animator.SetFloat("Turning", playerMovement.x);
    }
    public bool GetIsDead()
    {
        return isDead;
    }
    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
    void FireProjectile()
    {
        if (isAttacking)
        {
            if (nextAttackTime <= 0)
            {
                shooting.Fire();
                nextAttackTime = attackRate;
            }
        }
        nextAttackTime -= Time.deltaTime;
    }
}