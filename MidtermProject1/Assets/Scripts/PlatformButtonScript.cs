using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonScript : MonoBehaviour
{
    public Animator platformAnimator;
    public Animator buttonAnimator;
    public static bool isButtonPressed = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isButtonPressed = true;
            buttonAnimator.SetTrigger("ButtonPress");
            platformAnimator.SetTrigger("StartMoving");      
        }
    }
}
