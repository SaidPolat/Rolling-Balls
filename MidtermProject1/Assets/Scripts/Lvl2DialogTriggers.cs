using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lvl2DialogTriggers : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Animator transition;
    public int dialogCounter = 0;
    public Animator movingPlatform1;
    public Animator movingPlatformElevator;
    public GameObject button1;
    public GameObject button2;

    Level2ButtonsScript button1Scr;
    Level2ButtonsScript button2Scr;

    void Start()
    {
        button1Scr = button1.GetComponent<Level2ButtonsScript>();
        button2Scr = button2.GetComponent<Level2ButtonsScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        if (gameObject.name == "DialogPanelCloseTrigger" && dialogCounter == 0)
        {
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogEnteringRoomTrigger" && dialogCounter == 0)
        {
            textMesh.text = "There must be a lot of rooms\nLet's Start to discover";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "Don't forget to check everywhere. Every single point is valuable.";
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogMovingPlatformTrigger" && dialogCounter == 0)
        {
            textMesh.text = "This moving platforms look slippery, I think you should keep moving when you are on the platform";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(7f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "Be careful don't fall down";
            yield return new WaitForSeconds(2f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogElevatorTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Look there is a elevator.\n Let's check that";
            movingPlatformElevator.SetTrigger("Start");
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "You can't go further\nSo maybe check around for a way to get out";
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogElevatorButtonTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Aha, there is a button!\nIs this about the door which is closed?";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "Door1OpenTrigger")
        {
            if (Level2ButtonsScript.button1Pressed)
            {
                button1Scr.OpenDoor1();
                textMesh.text = "You did it! It is opened";             
            }
            else
            {
                textMesh.text = "We have to find a way to open this, check elevator maybe?";
            }
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");

        }
        else if (gameObject.name == "AfterStairsMPTrigger" && dialogCounter == 0)
        {
            movingPlatform1.SetTrigger("Start");
            textMesh.text = "Look There is a moving platform";      
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(4f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "Be patient about the where moving platform is going";
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "Maybe you have to wait for the platform to rise, so maybe you can reach the target";
            yield return new WaitForSeconds(8f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogDoor2Trigger")
        {
            if (Level2ButtonsScript.button2Pressed)
            {
                button2Scr.OpenDoor2();
                textMesh.text = "Nice, The Door is Opened!!";         
            }
            else
            {
                textMesh.text = "Check the upstairs for to open this door.";
            }
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
        }
        else if (gameObject.name == "DialogButton1Trigger" && dialogCounter == 0)
        {
            if (Level2ButtonsScript.button2Pressed)
            {
                textMesh.text = "There is a hole on the ground\nJump There";
                transition.SetTrigger("PanelOpen");
                yield return new WaitForSeconds(6f);
                transition.SetTrigger("PanelClose");
                dialogCounter++;
            }    
        }
        else if (gameObject.name == "DialogEnteringRoom2Trigger" && dialogCounter == 0)
        {
            textMesh.text = "This Cube looks different?\nTouch it to understand";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogSmallerSize1Trigger" && dialogCounter == 0)
        {
            textMesh.text = "If there is a Smaller Size PU, then there should be a hole that you can fit in it";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogPuzzle3Trigger" && dialogCounter == 0)
        {
            textMesh.text = "Well, These letters refers to something but I don't know";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogLevel2EndTrigger" && dialogCounter == 0)
        {
            textMesh.text = "You have completed the level, Jump outside for other level";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
       
    }
}
