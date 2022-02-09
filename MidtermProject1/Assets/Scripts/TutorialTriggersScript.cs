using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialTriggersScript : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Animator transition;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        transition.SetTrigger("ClosePage");

        yield return new WaitForSeconds(0.8f);

        if (gameObject.name == "MoveAirTTrigger")
        {
            textMesh.text = "This means that after you jumped, you can still control the ball!!\nIf you are going to miss the platform, you can press S to go back while in air";
        }

        if (gameObject.name == "JumpTTrigger")
        {
            textMesh.text = "Press SPACE for jump. You can do double jump if you click SPACE twice. But be careful, don't fall down!!";
        }

        if (gameObject.name == "ScoreTTrigger")
        {
            textMesh.text = "Collect these cubes for to increase your score. Left one is 1 Point, Right one is 3 Point. Higher score means higher star!";
        }

        if (gameObject.name == "SpikeTTrigger")
        {
            textMesh.text = "Try to avoid these spikes. Touching spike will cost you 1 Health bar. It is tutorial so you will not die. You can try";
        }

        if (gameObject.name == "HigherJumpTTrigger")
        {
            textMesh.text = "There are Power Ups that will give you buffs\nBlue one is 'Higher Jump'. This will increase your jumping speed";
        }

        if (gameObject.name == "SmallerSizeTTrigger")
        {
            textMesh.text = "Orange one is 'Smaller Size'\nWith the help of that\nYou can go through holes\nThat normally you can't fit";
        }

        if (gameObject.name == "HigherSpeedTTrigger")
        {
            textMesh.text = "Green one is 'Higher Speed'\nThis will give you huge speed buff";
        }

        if (gameObject.name == "BiggerSizeTTrigger")
        {
            textMesh.text = "Red one is 'Bigger Size'\nThis buff will increase your size\nAnd most importantly\nSpikes will not hurt you!";
        }

        if (gameObject.name == "FinishTTrigger")
        {
            textMesh.text = "You have finished the tutorial\nYou can jump down and start the action!";
        }
    }
}
