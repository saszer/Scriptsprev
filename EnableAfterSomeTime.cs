using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSomeTime : MonoBehaviour
{
    public GameObject ToEnable = null;
    public float Timetowait = 2f;

    private void Start()
    {
        StartCoroutine(Do());
    }

    IEnumerator Do()
    {
        yield return new WaitForSeconds(Timetowait);
        ToEnable.SetActive(true);
    }
}
