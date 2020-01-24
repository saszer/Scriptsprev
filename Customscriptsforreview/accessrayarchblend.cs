using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RaymarchingToolkit;
[RequireComponent(typeof(RaymarchModifier))]
[ExecuteInEditMode]
public class accessrayarchblend : MonoBehaviour
{
    RaymarchModifier obj;
    public string InputName;

    public float value;
    public bool lerp;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    static float t = 0.0f;
    float varyme;
    void Start()
    {
        obj = GetComponent<RaymarchModifier>();
    }
    void Update()
    {   
        var input = obj.GetInput(InputName);
        if (input != null)
        {
            input.floatValue = value;

        }

        if (lerp == true)
        {
            value = varyme;
            input.floatValue =
                varyme = (int)Mathf.Lerp(minimum, maximum, t);

            // .. and increase the t interpolater
            t += 0.02f * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
            }
        }

    }
}


