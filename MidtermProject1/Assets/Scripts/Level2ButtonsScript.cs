using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2ButtonsScript : MonoBehaviour
{
    public Animator door1Animator;
    public Animator door2Animator;
    public Animator door3Animator;
    public Animator door4Animator;
    public Animator button1Animator;
    public Animator button2Animator;
    public static bool button1Pressed = false;
    public static bool button2Pressed = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(gameObject.name == "OpenGateButton")
            {
                button1Animator.SetTrigger("ButtonPress");
                FindObjectOfType<AudioManager>().Play("ButtonPress");
                button1Pressed = true;
            }
            if (gameObject.name == "OpenGateButton2")
            {
                button2Animator.SetTrigger("ButtonPress");
                FindObjectOfType<AudioManager>().Play("ButtonPress");
                button2Pressed = true;
            }
        }   
    }

    public void OpenDoor1()
    {
        FindObjectOfType<AudioManager>().Play("DoorOpening");
        door1Animator.SetTrigger("OpenDoor");
        door2Animator.SetTrigger("OpenDoor");
    }
    public void OpenDoor2()
    {
        FindObjectOfType<AudioManager>().Play("DoorOpening");
        door3Animator.SetTrigger("OpenDoor");
        door4Animator.SetTrigger("OpenDoor");
    }

}
