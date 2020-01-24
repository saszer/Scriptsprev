using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedrotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.eulerAngles = new Vector3(50, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
