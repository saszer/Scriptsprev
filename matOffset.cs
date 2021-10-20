using System;
using System.Collections;
using System.Collections.Generic;
using EndOfScenarioGame.UI;
using UnityEngine;
//sz
public class matOffset : MonoBehaviour
{
    [SerializeField] private Material _material;
    
    static float t = 0.0f;
    private float start = 0;
    private int x = 0;

    public float spinoffsetspeed = 1f;


    void Update()
    {

        //Detail Offset Spinner>>
        if (start == 0)
        {
            t = 0.0f;
        }
        start = Mathf.Lerp(1, x, t);
        _material.SetTextureOffset("_DetailAlbedoMap", new Vector2(start,0));
        t += 0.5f * Time.deltaTime * spinoffsetspeed;
    }

    private void OnDisable()
    {
        _material.SetTextureOffset("_DetailAlbedoMap", new Vector2(0,0));
    }
}
