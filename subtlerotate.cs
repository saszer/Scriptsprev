using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtlerotate : MonoBehaviour
{
    //sz.sahaj@embracingearth.space
    void Start()
    {
        
    }

    public float speed = 2f;
    public float maxRotation = 45f;
    [Header("Rotate baxk and forth// can only choose work on axis at a time //sz")]
    public bool x;
    public bool y;
    public bool z;


    void Update()
    {
        if(x)
            transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * speed), 0f, 0f);
        if (y)
            transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * speed), 0f);
        if (z)
            transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }
}
