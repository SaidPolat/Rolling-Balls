using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float jumpingSpeed = 10f;
    public float speed = 900f;
    public float maxSpeed = 25f;
    public int playerHealth = 3;
    public bool haveBiggerPU = false;

    public static bool isInTutorial = false;
    public static bool isInLevel1 = false;
    public static bool isInLevel2 = false;
    public static bool isInGameOver = false;
    public static bool isInMainMenu = true;


    void Update()
    {
        if(playerHealth == 0 && (isInLevel1 || isInLevel2))
        {
            isInGameOver = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(3);
        }   
    }

   
}
