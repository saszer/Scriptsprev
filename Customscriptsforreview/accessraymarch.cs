using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RaymarchingToolkit;
[RequireComponent(typeof(RaymarchObject))]
[ExecuteInEditMode]
public class accessraymarch : MonoBehaviour
{
    RaymarchObject obj;
    public string InputName;
    public Color ColorValue;
    
    public float _speed = 0.1f;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    public float t = 0.0f;
    float varyme;
    void Start()
    {
        obj = GetComponent<RaymarchObject>();
    }
    void Update()
    {   
        var input = obj.GetMaterialInput(InputName);
        if (input != null)
        {
            input.floatValue = varyme;

        }
        input.floatValue = 
            varyme = (int)Mathf.SmoothStep(minimum, maximum, t);

        // .. and increase the t interpolater
        t += _speed * Time.deltaTime;

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

