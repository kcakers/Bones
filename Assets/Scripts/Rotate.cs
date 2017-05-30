using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public Animator anim;

    private bool touching = false;
    private Quaternion originalRotation;

    [HideInInspector]
    public bool isRotating = false;

    void Start()
    {
        originalRotation = target.transform.rotation;
    }

    void Update()
    {
        float joyDistance = Input.GetAxis("Horizontal1");

        if (joyDistance != 0)
        {
            anim.enabled = false;
        } else
        {
            anim.enabled = true;
        }

        target.transform.Rotate(0, joyDistance * 100 * Time.deltaTime, 0, Space.World);
    }
}