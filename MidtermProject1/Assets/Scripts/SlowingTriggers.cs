using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTriggers : MonoBehaviour
{
    Rigidbody rigid;

    void OnTriggerEnter(Collider other)
    {
        rigid = other.GetComponent<Rigidbody>();
        rigid.velocity = new Vector3(0f, 0f, 0f);
    }
}
