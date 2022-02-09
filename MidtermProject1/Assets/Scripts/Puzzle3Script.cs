using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Script : MonoBehaviour
{
    public static bool isPuzzle3RTrue = false;
    public static bool isPuzzle3GTrue = false;
    public static bool isPuzzle3BTrue = false;

    public Animator rLight;
    public Animator gLight;
    public Animator bLight;
    public Animator rText;
    public Animator gText;
    public Animator bText;
 

    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.name == "Puzzle3R")
        {
            if (collision.gameObject.CompareTag("Puzzle3R"))
            {
                isPuzzle3RTrue = true;
                rLight.SetTrigger("OpenLight");
                rText.SetTrigger("StopMove");
                gameObject.SetActive(false);
            }
        }
        if (gameObject.name == "Puzzle3G")
        {
            if (collision.gameObject.CompareTag("Puzzle3G"))
            {
                isPuzzle3GTrue = true;
                gLight.SetTrigger("OpenLight");
                gText.SetTrigger("StopMove");
                gameObject.SetActive(false);
            }
        }
        if (gameObject.name == "Puzzle3B")
        {
            if (collision.gameObject.CompareTag("Puzzle3B"))
            {
                isPuzzle3BTrue = true;
                bLight.SetTrigger("OpenLight");
                bText.SetTrigger("StopMove");
                gameObject.SetActive(false);
            }
        }
    }
}
