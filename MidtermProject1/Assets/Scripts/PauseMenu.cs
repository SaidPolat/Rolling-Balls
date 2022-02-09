using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject player;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMain;
    public GameObject settingsScreen;
    public GameObject audioScreen;
    public GameObject graphicsScreen;
    public GameObject sensivityScreen;
    public Animator transition;
    AudioSource audioSource;
    public Slider sliderMusic;
    public Slider sliderSfx;
    public TMP_Dropdown aaDropdown;

    void Start()
    {
        Debug.Log("SettingsMenu.musicVolume " + SettingsMenu.musicVolume);
        Debug.Log("SettingsMenu.sfxVolume " + SettingsMenu.sfxVolume);
        audioSource = player.gameObject.GetComponent<AudioSource>();
        sliderMusic.value = SettingsMenu.musicVolume;
        sliderSfx.value = SettingsMenu.sfxVolume;
        aaDropdown.value = CameraSettings.dropdownValue;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        audioSource.Play();
        pauseMain.SetActive(true);
        settingsScreen.SetActive(false);
        audioScreen.SetActive(false);
        graphicsScreen.SetActive(false);
        sensivityScreen.SetActive(false);
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        audioSource.Pause();
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        PlayerStats.isInTutorial = false;
        PlayerStats.isInLevel1 = false;
        PlayerStats.isInLevel2 = false;
        PlayerStats.isInMainMenu = true;
        PlayerControl.scoreList.Add(PlayerControl.playersMaxScore);
        PlayerControl.playersMaxScore = 0;
        PlayerControl.onGoingTotalScore = 0;
        PlayerControl.endGameScore = 0;
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitFromGame()
    {
        Application.Quit();
    }

    IEnumerator RestartLevel()
    {
        int lvlIndex = 2;
        if (PlayerStats.isInTutorial)
            lvlIndex = 1;
        if (PlayerStats.isInLevel1)
            lvlIndex = 4;
        if (PlayerStats.isInLevel2)
            lvlIndex = 2;

        transition.SetTrigger("LevelClosing");
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(lvlIndex);

    }

    public void SkipTutorialButton()
    {
        PlayerStats.isInTutorial = false;
        PlayerStats.isInLevel1 = true;
        StartCoroutine(SkipTutorial());
    }

    IEnumerator SkipTutorial()
    {
        transition.SetTrigger("LevelClosing");
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(4);
    }

    public void RestartLevelButton()
    {
        PlayerControl.endGameScore = 0;
        StartCoroutine(RestartLevel());
    }

    public void SettingsButton()
    {
        pauseMain.SetActive(false);
        settingsScreen.SetActive(true);

    }

    public void BackToMenuButtonFromSettings()
    {
        pauseMain.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void BackToSettingsButtonFromSensivity()
    {
        settingsScreen.SetActive(true);
        sensivityScreen.SetActive(false);
    }

    public void BackToSettingsButtonFromGraphics()
    {
        settingsScreen.SetActive(true);
        graphicsScreen.SetActive(false);
    }

    public void BackToSettingsButtonFromAudio()
    {
        settingsScreen.SetActive(true);
        audioScreen.SetActive(false);
    }

    public void GoSensScreen()
    {
        settingsScreen.SetActive(false);
        sensivityScreen.SetActive(true);
    }

    public void GoGrapScreen()
    {
        settingsScreen.SetActive(false);
        graphicsScreen.SetActive(true);
    }

    public void GoAudioScreen()
    {
        settingsScreen.SetActive(false);
        audioScreen.SetActive(true);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetMusicVolume(float volume)
    {
        for(int i = 0; i < 3; i++)
        {
            audioManager.sounds[i].volume = volume;
        } 
    }

    public void SetSfxVolume(float volume)
    {
        for(int i = 4; i < 7; i++)
        {
            audioManager.sounds[i].volume = volume - 1.3f;
        }
        for(int i = 7; i < 12; i++)
        {
            audioManager.sounds[i].volume = volume;
        }
    }
}
