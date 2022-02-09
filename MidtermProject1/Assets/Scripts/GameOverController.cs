using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public Animator transition;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        int totalScoreInt = PlayerControl.endGameScore + PlayerControl.onGoingTotalScore;

        textMesh.text = "SCORE: " + totalScoreInt;

        if (PlayerControl.playersMaxScore <= totalScoreInt)
        {
            PlayerControl.playersMaxScore = totalScoreInt;
        }

    }

    public void RestartLevelButton()
    {
        PlayerStats.isInGameOver = false;
        PlayerControl.endGameScore = 0;
        StartCoroutine(RestartLevel());
    }

    public void StartNewGameButton()
    {
        PlayerStats.isInGameOver = false;
        PlayerStats.isInLevel1 = true;
        PlayerStats.isInLevel2 = false;
        PlayerControl.onGoingTotalScore = 0;
        PlayerControl.playersMaxScore = 0;
        PlayerControl.endGameScore = 0;
        StartCoroutine(StartNewGame());
    }

    public void ReturnToMenuButton()
    {
        PlayerStats.isInGameOver = false;
        PlayerStats.isInLevel1 = false;
        PlayerStats.isInLevel2 = false;
        PlayerStats.isInMainMenu = true;
        PlayerControl.scoreList.Add(PlayerControl.playersMaxScore);
        PlayerControl.playersMaxScore = 0;
        PlayerControl.onGoingTotalScore = 0;
        PlayerControl.endGameScore = 0;
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        transition.SetTrigger("GameOverScreenStart");
        yield return new WaitForSeconds(2);   
        SceneManager.LoadSceneAsync(0);
    }

    IEnumerator StartNewGame()
    {
        transition.SetTrigger("GameOverScreenStart");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(2);
    }

    IEnumerator RestartLevel()
    {
        int lvlIndex = 2;

        if (PlayerStats.isInLevel1)
            lvlIndex = 4;
        if (PlayerStats.isInLevel2)
            lvlIndex = 2;

        transition.SetTrigger("GameOverScreenStart");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(lvlIndex);
    }
}
