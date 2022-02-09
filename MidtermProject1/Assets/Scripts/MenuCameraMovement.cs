using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
