using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReleaseTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerControl.alreadyHitButton = false;
        PlayerControl.onButton = false;
        if (!PlayerControl.onButton)
        {
            PlayerControl.doResetButton = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!PlayerControl.onButton)
        {
            PlayerControl.doResetButton = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerControl.doResetButton = false;   
    }
}
