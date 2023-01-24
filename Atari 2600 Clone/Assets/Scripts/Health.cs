using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Refrence")]
    [SerializeField] GameObject explosionPrefab;

    [Header("Settings")]
    [SerializeField] int health = 100;
    [SerializeField] int score = 10;
    [SerializeField] bool isPlayer;

    CameraAnimation cameraAnimation;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraAnimation = Camera.main.GetComponent<CameraAnimation>();
        audioManager = FindObjectOfType<AudioManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();
        if (damage != null)
        {
            TakeDamage(damage.GetDamage());
            ShakeCamera();
            damage.Hit();
            audioManager.PlayTakeDamageClip();
            InstantExplosionPrefab(other);
        }
    }

    void InstantExplosionPrefab(Collider2D other)
    {
        GameObject instant = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
        Destroy(instant, 0.51f);
    }

    void TakeDamage(int takenDamage)
    {
        health -= takenDamage;
        if (health <= 0)
        {
            health = 0;
            ProcessDeath();
        }
    }

    void ProcessDeath()
    {
        if (!isPlayer)
        {
            scoreKeeper.SetScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void ShakeCamera()
    {
        if (isPlayer)
        {
            cameraAnimation.Play();
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
