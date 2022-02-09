using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Script : MonoBehaviour
{
    public Animator animatorPuzzle;

    public GameObject PuzzleButton;
    public bool isPuzzlePieceTrue;
    
    public int rotationHolder;

    
    void Start()
    {
        int rotationHolderMod = rotationHolder % 3;

        if (rotationHolderMod == 1)
        { 
            animatorPuzzle.SetTrigger("Puzzle23To1");
        }
        if (rotationHolderMod == 2)
        {
            animatorPuzzle.SetTrigger("Puzzle23To1");
            animatorPuzzle.SetTrigger("Puzzle21To2");
        }
 
    }

    void Update()
    {
        if (rotationHolder % 3 == 0)
        {
            isPuzzlePieceTrue = true;
        }
    }

    public void ButtonPressed()
    {
        int rotationHolderMod = rotationHolder % 3;
        if (rotationHolderMod == 0)
        {
            animatorPuzzle.SetTrigger("Puzzle23To1"); 
            isPuzzlePieceTrue = false;
        }
        if (rotationHolderMod == 1)
        {
            animatorPuzzle.SetTrigger("Puzzle21To2");
            isPuzzlePieceTrue = false;
        }
        if (rotationHolderMod == 2)
        {
            animatorPuzzle.SetTrigger("Puzzle22To3");
            isPuzzlePieceTrue = true;
        }

        rotationHolder += 1;
    }
}
