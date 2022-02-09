using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBasketCheckScript : MonoBehaviour
{
    public static bool isBasket = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBasket = true;
            
        }   
    }
}
