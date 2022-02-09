using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;

    public void RespawnToTarget()
    {
        player.transform.position = respawnPoint.transform.position;
    }

   
}
