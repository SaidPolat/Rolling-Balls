using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1DialogTriggers : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Animator transition;
    public int dialogCounter = 0;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartAnimation());    
    }

    IEnumerator StartAnimation()
    {
        if(gameObject.name == "DialogPanelCloseTrigger" && dialogCounter == 0)
        {
            transition.SetTrigger("PanelClose");
            dialogCounter++;           
        }
        else if(gameObject.name == "DialogEnteringRoomTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Wow! This place is huge. We got to get out of here and move on. Find the Exit";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "Don't forget to check everywhere. Every single point is valuable.";
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if(gameObject.name == "DialogMovingPlatformsTrigger" && dialogCounter == 0)
        {
            textMesh.text = "This platforms look slippery, be careful don't fall down";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "I think you should keep moving when you are on the platform";
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if(gameObject.name == "DialogPuzzle1Trigger" && dialogCounter == 0)
        {
            textMesh.text = "Hmm, it looks like some kind of puzzle. I think you should match the lines";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("TextClose");
            yield return new WaitForSeconds(0.8f);
            textMesh.text = "You can't go further\nSo maybe check around for a way to get out";
            yield return new WaitForSeconds(6f);         
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogPuzzle1PowerUpTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Hurry Up or you will lose the power up!!!\nGO GO GO";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f); 
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogPuzzle1EndTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Phew, that was impresive\nWell Played!!\nMove on to the next then";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogBigRampTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Can you pick up all scores at one shot?\nWell there is only one way to learn\nGooo!";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
        else if (gameObject.name == "DialogButtonForMPTrigger" && dialogCounter == 0)
        {
            if(PlatformButtonScript.isButtonPressed == false)
            {
                textMesh.text = "It is not moving.\nI think you forgot something";
                transition.SetTrigger("PanelOpen");
                yield return new WaitForSeconds(6f);
                transition.SetTrigger("PanelClose");
                dialogCounter++;
            }
            else
            {
                textMesh.text = "Hmm, it looks like a new puzzle";
                transition.SetTrigger("PanelOpen");
                yield return new WaitForSeconds(3.5f);
                transition.SetTrigger("PanelClose");
                dialogCounter++;
            }  
        }
        else if (gameObject.name == "DialogPuzzle2Trigger" && dialogCounter == 0)
        {
            textMesh.text = "Well, is that a colour matching?, Look for paterns";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        } 
        else if (gameObject.name == "DialogBasketTrigger" && dialogCounter == 0)
        {
            if(IsBasketCheckScript.isBasket == false)
            {
                textMesh.text = "Come oon, don't go for easy, Just score to continue";
                transition.SetTrigger("PanelOpen");
                yield return new WaitForSeconds(3.5f);
                transition.SetTrigger("PanelClose");
                dialogCounter++;
            }  
        }
        else if (gameObject.name == "DialogLevel1EndTrigger" && dialogCounter == 0)
        {
            textMesh.text = "Nice job, You have completed the level 1\nGo through the Main Door for next level";
            transition.SetTrigger("PanelOpen");
            yield return new WaitForSeconds(6f);
            transition.SetTrigger("PanelClose");
            dialogCounter++;
        }
    }
}
