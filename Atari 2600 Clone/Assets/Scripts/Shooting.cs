using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] bool IsPlayer = true;
    AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        StartCoroutine(FireContinuously());
    }
    public void Fire()
    {
        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        audioManager.PlayPlayerShootingClip();
    }

    IEnumerator FireContinuously()
    {
        while (!IsPlayer)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, 180));
            audioManager.PlayEnemyShootingClip();
            yield return new WaitForSeconds(Random.Range(0.3f, 1.5f));
        }
    }
}
