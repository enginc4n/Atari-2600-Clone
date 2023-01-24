using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Health playerHealth;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = 0.ToString();
        healthText.text = playerHealth.GetHealth().ToString();
    }
    void Update()
    {
        UpdateScore();
        UpdateHealth();
    }
    void UpdateScore()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
    void UpdateHealth()
    {
        healthText.text = playerHealth.GetHealth().ToString();
    }
}
