using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip playerShootingClip;
    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume;
    [Header("Take Damage")]
    [SerializeField] AudioClip takeDamageClip;
    [SerializeField][Range(0f, 1f)] float takeDamageVolume;
    void Awake()
    {
        int numberOfAudioManager = FindObjectsOfType<AudioManager>().Length;
        if (numberOfAudioManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayPlayerShootingClip()
    {
        PlayClip(playerShootingClip, shootingVolume);
    }
    public void PlayEnemyShootingClip()
    {
        PlayClip(enemyShootingClip, shootingVolume);
    }
    public void PlayTakeDamageClip()
    {
        PlayClip(takeDamageClip, takeDamageVolume);
    }
    void PlayClip(AudioClip audioClip, float volume)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }
}
