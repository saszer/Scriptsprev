using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyposistionofanobject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform leadingObject; 
    public Transform followingObject;

    void Update()
    {
        followingObject.transform.position = leadingObject.transform.position;
    }
}
