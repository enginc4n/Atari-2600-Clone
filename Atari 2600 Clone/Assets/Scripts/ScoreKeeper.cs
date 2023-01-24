using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    void Awake()
    {
        int numberOfScoreKeeper = FindObjectsOfType<ScoreKeeper>().Length;
        if (numberOfScoreKeeper > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }
    }
    int score = 0;
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int scorePoint)
    {
        score += scorePoint;
    }
    public void ResetScore()
    {
        score = 0;
    }
}
