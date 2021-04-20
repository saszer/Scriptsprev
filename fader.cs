using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class fader : MonoBehaviour
{
    public UnityEvent OnStartFadeover;
    public UnityEvent OnEndFadeover;
    public Image image;
    public float targetAlpha = 0;
    public float FadeRate = 2;

    bool fading = false;
    private void Start()
    {
        fading = false;
    }
    public void FadeNow()
    {
        if (fading == false)
        {
            StartCoroutine(Fade());
            fading = true;
        }
    }
    IEnumerator Fade()
    {
        OnStartFadeover.Invoke();
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.1f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        OnEndFadeover.Invoke();
        image.gameObject.SetActive(false);
    }
}
