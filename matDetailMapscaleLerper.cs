using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sz.sahaj@embracingearth.space - to increase value of detail map on urp mat

public class matDetailMapscaleLerper : MonoBehaviour
{
    
    [SerializeField] private Material _material;
    [SerializeField] private float delay = 3f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float iteratespeed = 2f;
    [SerializeField] private float setvalueto = 1.7f;
    [SerializeField] private bool alreadydone = false;
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseBasemap());
    }
    IEnumerator IncreaseBasemap()
    {
        yield return new WaitForSeconds(delay);
        float elapsedTime = 0;
        float waitTime = speed;
        var x = 0f;

        if (!alreadydone)
        {
            while (elapsedTime < waitTime)
            {
                x = Mathf.Lerp(0, setvalueto, elapsedTime/waitTime);
                _material.SetFloat("_DetailAlbedoMapScale", x);
                elapsedTime += Time.deltaTime;
                yield return new WaitForSeconds(iteratespeed);
            }
        }
        _material.SetFloat("_DetailAlbedoMapScale", setvalueto);
        yield return null;
    }
    
    private void OnApplicationQuit()
    {
        _material.SetFloat("_DetailAlbedoMapScale", 0f);
    }
}
