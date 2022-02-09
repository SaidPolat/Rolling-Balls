using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Script : MonoBehaviour
{
    public Animator animatorPuzzle;
    
    public bool isPuzzlePieceTrue;
    
    public int rotationHolder;

    void Start()
    {
        int rotationHolderMod = rotationHolder % 4;
        if (rotationHolderMod == 1)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo90");
        }
        if(rotationHolderMod == 2)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo90");
            animatorPuzzle.SetTrigger("RotatePuzzleTo180");
        }
        if (rotationHolderMod == 3)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo90");
            animatorPuzzle.SetTrigger("RotatePuzzleTo180");
            animatorPuzzle.SetTrigger("RotatePuzzleTo270");
        }
    }

    void Update()
    {  
        if(rotationHolder % 4 == 0)
        {
            isPuzzlePieceTrue = true;
        }

    }

    public void ButtonPressed()
    {
        int rotationHolderMod = rotationHolder % 4;
        if (rotationHolderMod == 0)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo90");
            isPuzzlePieceTrue = false;
        }
        if (rotationHolderMod == 1)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo180");
            isPuzzlePieceTrue = false;
        }
        if (rotationHolderMod == 2)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo270");
            isPuzzlePieceTrue = false;
        }
        if (rotationHolderMod == 3)
        {
            animatorPuzzle.SetTrigger("RotatePuzzleTo0");
            isPuzzlePieceTrue = true;
        }

        rotationHolder += 1;
    }
}
