using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void OpenLinkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/enginc4n/");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        scoreKeeper.ResetScore();
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitThenLoad(2, 1.5f));
    }
    IEnumerator WaitThenLoad(int index, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(index);
    }
}
