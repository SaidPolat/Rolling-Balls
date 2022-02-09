using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPositionScript : MonoBehaviour
{
    public Transform target;
    public Transform cam;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
        transform.position = target.position + offset;
    }
}
