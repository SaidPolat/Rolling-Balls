using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1ButtonsScript : MonoBehaviour
{
    public Animator buttonAnimator;
    
    public GameObject puzzle1;

    Puzzle1Script scA;

    void Start()
    {
        scA = puzzle1.GetComponent<Puzzle1Script>();
    }

    public void PressButon()
    {
        buttonAnimator.SetTrigger("PuzzleButtonPress");
        scA.ButtonPressed();
    }

    public void ExitButton()
    {
        buttonAnimator.SetTrigger("PuzzleButtonExit");
    }

    public void HoldButton()
    {
        buttonAnimator.SetTrigger("PuzzleButtonHold");
    }
    
}
