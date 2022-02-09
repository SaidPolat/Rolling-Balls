using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBall : MonoBehaviour
{
    Rigidbody rigid;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();     
    }

    void FixedUpdate()
    {
        rigid.AddForce(new Vector3(0f, 0f, 0.4f));

    }
}
