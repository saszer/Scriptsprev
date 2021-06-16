using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// FadeOut Image On Enable //sz.sahaj@embracingearth.space
/// </summary>
public class FadeOutAfterEnable : MonoBehaviour
{
    public float DelayBeforStartingFadeOut = 2f;
    public float FadeRate;
    public Image image = null;
    public TextMeshProUGUI[] textMeshPro;
    public float targetAlpha;
    public bool DeactivateGameObjectAfterFade;
    public bool DestroyGameObjectAfterFade;
    public GameObject ToDestroy;
    Color curColor;
    Color defaultColorImage;
    Color defaultColortext;
    private void Awake()
    {
        if(image !=null)
            defaultColorImage = image.color;
        
        if (textMeshPro != null)
        {
            defaultColortext = textMeshPro[0].color;
        }
    }

    private void OnEnable()
    {
        if(image !=null)
            image.color = defaultColorImage;
        if (textMeshPro != null)
        {
            for (int i = 0; i < textMeshPro.Length; i++)
            {
                textMeshPro[i].color = defaultColortext;
            }
        }
        StartCoroutine(Hey());
    }

    IEnumerator Hey()
    {
        yield return new WaitForSeconds(DelayBeforStartingFadeOut);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        if(image !=null)
            curColor = image.color;
        if (textMeshPro != null)
            curColor = textMeshPro[0].color;
        
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            if(image !=null)
                image.color = curColor;
            
            if (textMeshPro != null)
            {
                for(int i=0;i< textMeshPro.Length; i++)
                {
                    textMeshPro[i].color = curColor;
                }
            }
            yield return null;
        }
        gameObject.SetActive(false);

        if (DeactivateGameObjectAfterFade)
            this.gameObject.SetActive(false);

        if (DestroyGameObjectAfterFade)
            Destroy(ToDestroy);
    }
}
