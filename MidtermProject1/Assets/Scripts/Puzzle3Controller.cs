using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle3Controller : MonoBehaviour
{
    public Animator dialogAnimator;
    public TextMeshProUGUI textMesh;
    public Animator doorAnimator1;
    public Animator doorAnimator2;
    public Animator text3d;
    int basicCounter = 0;
    
    void Update()
    {
        if(Puzzle3Script.isPuzzle3RTrue && Puzzle3Script.isPuzzle3GTrue && Puzzle3Script.isPuzzle3BTrue && basicCounter == 0)
        {
            PuzzleIsCompleted();
            basicCounter++;
        }
    }

    public void PuzzleIsCompleted()
    {
        FindObjectOfType<AudioManager>().Play("PuzzleComplete");
        doorAnimator1.SetTrigger("OpenDoor");
        doorAnimator2.SetTrigger("OpenDoor");

        StartCoroutine(DialogOpen());
    }

    IEnumerator DialogOpen()
    {
        text3d.SetTrigger("Open");
        textMesh.text = "You've Made It!\nLook door is opening";
        dialogAnimator.SetTrigger("PanelOpen");
        yield return new WaitForSeconds(4f);
        dialogAnimator.SetTrigger("PanelClose");
    }
}
