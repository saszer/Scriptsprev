using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rECALLzEDrENDERsETS : MonoBehaviour
{


    public ZEDManager _zedmanager;
    // Start is called before the first frame update
    void OnEnable()
    {
        _zedmanager.setRenderingSettings();
    }


}
