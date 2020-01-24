using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class disablevrpostionaltracking : MonoBehaviour
{ public Camera _Camtodisable;
    bool disabled = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
        XRDevice.DisableAutoXRCameraTracking(_Camtodisable, disabled);
        gameObject.transform.Translate(0, 0, 0);
        transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
     

    }
}
