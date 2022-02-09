using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public GameObject player;
    public GameObject fillBar1;
    public GameObject fillBar2;
    public GameObject fillBar3;
    PlayerStats stats;

    void Start()
    {
        stats = player.GetComponent<PlayerStats>();
    }

    
    void Update()
    {
        if(stats.playerHealth == 3)
        {
            if (fillBar3.activeSelf == false)
                fillBar3.SetActive(true);
        }
        if(stats.playerHealth == 2)
        {
            fillBar3.SetActive(false);

            if(fillBar2.activeSelf == false)
                fillBar2.SetActive(true);
        }
        if (stats.playerHealth == 1)
        {
            fillBar2.SetActive(false);

        }
        if (stats.playerHealth == 0)
        {
            fillBar1.SetActive(false);
        }
    }
}
