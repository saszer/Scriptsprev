using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnableMagnify : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cam;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cam.GetComponent<MagnifyingGlassFisheyeWarpImageEffect>().enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cam.GetComponent<MagnifyingGlassFisheyeWarpImageEffect>().enabled = false;
    }
}