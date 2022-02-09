using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject enterNameScreen;
    public GameObject startPlayScreen;
    public GameObject settingsScreen;
    public GameObject scoreboardScreen;
    public AudioManager audioManager;

    public Animator transition;
    public Animator playScreenTransition;
    public Animator warningAnimator;
    public InputField iField;
    public static string myName;
    public static List<string> namesList = new List<string>();
    private bool opening = true;
    private bool levelPanelOpen = false;

    void Start()
    {
        SettingsMenu.musicVolume = 0.405f;
        SettingsMenu.sfxVolume = 0.485f;
        StartCoroutine(StartPressAnyKey());
    }

    void Update()
    {

        if (Input.anyKeyDown && opening)
        {
            LoadNextScreen();
            opening = false;
        }
    }

    public void LoadEnterNameScreen()
    {
        StartCoroutine(LoadScreen(secondScreen, enterNameScreen));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenuFromName()
    {
        StartCoroutine(LoadScreen(enterNameScreen, secondScreen));
    }

    public void LoadScoreboardScreen()
    {
        StartCoroutine(LoadScreen(secondScreen, scoreboardScreen));
    }

    public void ReturnToMenuFromScoreboard()
    {
        StartCoroutine(LoadScreen(scoreboardScreen , secondScreen));
    }

    public void LoadStartPlayScreen()
    {
        myName = iField.text;
        if(iField.text == "")
        {
            warningAnimator.SetTrigger("Start");
        }
        else
        {
            namesList.Add(myName);
            StartCoroutine(LoadScreen(enterNameScreen, startPlayScreen));
        }
        
    }

    public void LoadSettingsScreen()
    {
        StartCoroutine(LoadScreen(secondScreen, settingsScreen));
    }

    public void LoadMenuFromSettings()
    {
        StartCoroutine(LoadScreen(settingsScreen, secondScreen));
    }

    public void LoadNextScreen()
    {
        StartCoroutine(LoadScreen(firstScreen, secondScreen));
    }

    public void LoadTutorialLevelButton()
    {
        StartCoroutine(LoadTutorialLevel());
    }

    public void ChooseLevel1Button()
    {
        StartCoroutine(LoadLevel1());
    }

    public void ChooseLevel2Button()
    {
        StartCoroutine(LoadLevel2());
    }

    IEnumerator LoadLevel1()
    {
        PlayerStats.isInMainMenu = false;
        PlayerStats.isInLevel1 = true;
        audioManager.Play("MenuButtonPress");
        transition.SetTrigger("StartPlayScreenStart");
        yield return new WaitForSeconds(2);
        startPlayScreen.SetActive(false);
        firstScreen.SetActive(true);
        SceneManager.LoadSceneAsync(4);
    }

    IEnumerator LoadLevel2()
    {
        PlayerStats.isInMainMenu = false;
        PlayerStats.isInLevel2 = true;
        audioManager.Play("MenuButtonPress");
        transition.SetTrigger("StartPlayScreenStart");
        yield return new WaitForSeconds(2);
        startPlayScreen.SetActive(false);
        firstScreen.SetActive(true);
        SceneManager.LoadSceneAsync(2);
    }

    public void OpenLevelsPanel()
    {
        audioManager.Play("MenuButtonPress");
        if (!levelPanelOpen)
        {
            playScreenTransition.SetTrigger("BringLevels");
            levelPanelOpen = true;
        }
        else
        {
            playScreenTransition.SetTrigger("CloseLevels");
            levelPanelOpen = false;
        }
        
    }

    IEnumerator LoadTutorialLevel()
    {
        PlayerStats.isInMainMenu = false;
        PlayerStats.isInTutorial = true;
        audioManager.Play("MenuButtonPress");
        transition.SetTrigger("StartPlayScreenStart");
        yield return new WaitForSeconds(2);
        startPlayScreen.SetActive(false);
        firstScreen.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

    IEnumerator LoadScreen(GameObject from, GameObject to)
    {
        audioManager.Play("MenuButtonPress");
        string firstName = from.name;
        string secondName = to.name;

        transition.SetTrigger(firstName + "Start"); 

        yield return new WaitForSeconds(1);

        from.SetActive(false);

        to.SetActive(true);

        transition.SetTrigger(secondName + "End");

        yield return new WaitForSeconds(1);

    }

    IEnumerator StartPressAnyKey()
    {
        yield return new WaitForSeconds(1.1f);

        transition.SetTrigger("pressAnyKey");
    }
}
