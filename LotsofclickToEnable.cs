using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LotsofclickToEnable : MonoBehaviour
{
    public int clickno = 0;
    public int numberofclicks = 5;
    public float DowithinTime = 3f;
    public UnityEvent Do;
    private void Start()
    {
        clickno = 0;
    }

    private void OnEnable()
    {
        clickno = 0;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    public void Click() //call from button
    {
        clickno++;
        if (clickno == 1)
        {
            StartCoroutine(ClickIn());
        }
        if (clickno > numberofclicks)
        {
            Do.Invoke();
        }

    }

    // Update is called once per frame
    IEnumerator ClickIn()
    {
        yield return new WaitForSeconds(DowithinTime);
        clickno = 0;
    }
}
