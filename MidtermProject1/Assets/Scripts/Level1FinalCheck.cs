using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1FinalCheck : MonoBehaviour
{
    public Animator part2DoorAnimator;
    public Animator finalDoorAnimator;


    void OnTriggerEnter(Collider other)
    {
        part2DoorAnimator.SetTrigger("OpenDoor");

        if(Puzzle2Controller.isPuzzle2Completed && Puzzle1Controller.isPuzzle1Completed)
        {
            StartCoroutine(OpenFinalDoor());
        }
   
    }

    IEnumerator OpenFinalDoor()
    {
        yield return new WaitForSeconds(4f);

        finalDoorAnimator.SetTrigger("OpenDoor");
    }

}
