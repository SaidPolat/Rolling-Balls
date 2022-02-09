using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2ButtonScript : MonoBehaviour
{
    public Animator buttonAnimator;

    public GameObject puzzle2;

    Puzzle2Script scA;

    void Start()
    {
        scA = puzzle2.GetComponent<Puzzle2Script>();
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



