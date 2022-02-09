using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle1Controller : MonoBehaviour
{
    public static bool isPuzzle1Completed = false;

    private int basicCounter = 0;

    public GameObject puzzle1a;
    public GameObject puzzle1b;
    public GameObject puzzle1c;
    public GameObject puzzle1d;
    public GameObject puzzle1e;
    public GameObject puzzle1f;
    public GameObject puzzle1g;
    public GameObject puzzle1h;

    public TextMeshProUGUI textMesh;
    public Animator doorAnimator;
    public Animator puzzleLightAnimator;
    public Animator dialogAnimator;
    public Animator text3dAnimator;

    Puzzle1Script scA;
    Puzzle1Script scB;
    Puzzle1Script scC;
    Puzzle1Script scD;
    Puzzle1Script scE;
    Puzzle1Script scF;
    Puzzle1Script scG;
    Puzzle1Script scH;

    void Start()
    {
        scA = puzzle1a.GetComponent<Puzzle1Script>();
        scB = puzzle1b.GetComponent<Puzzle1Script>();
        scC = puzzle1c.GetComponent<Puzzle1Script>();
        scD = puzzle1d.GetComponent<Puzzle1Script>();
        scE = puzzle1e.GetComponent<Puzzle1Script>();
        scF = puzzle1f.GetComponent<Puzzle1Script>();
        scG = puzzle1g.GetComponent<Puzzle1Script>();
        scH = puzzle1h.GetComponent<Puzzle1Script>();
        
    }

    
    void Update()
    {
        if(scA.isPuzzlePieceTrue && scB.isPuzzlePieceTrue && scC.isPuzzlePieceTrue && scD.isPuzzlePieceTrue && scE.isPuzzlePieceTrue && scF.isPuzzlePieceTrue && scG.isPuzzlePieceTrue && scH.isPuzzlePieceTrue && basicCounter == 0)
        {
            PuzzleIsCompleted();
            basicCounter++;
        }
    }

    public void PuzzleIsCompleted()
    {
        FindObjectOfType<AudioManager>().Play("PuzzleComplete");
        text3dAnimator.SetTrigger("Start");
        doorAnimator.SetTrigger("OpenDoor");
        puzzleLightAnimator.SetTrigger("PuzzleLightOpen");
        FindObjectOfType<AudioManager>().Play("DoorOpening");
        isPuzzle1Completed = true;
        StartCoroutine(DialogOpen());
    }

    IEnumerator DialogOpen()
    {
        textMesh.text = "You've Made It!\nLook door is opening";
        dialogAnimator.SetTrigger("PanelOpen");
        yield return new WaitForSeconds(4f); 
        dialogAnimator.SetTrigger("PanelClose");
    }
}
