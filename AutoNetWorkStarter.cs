using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class AutoNetWorkStarter : NetworkBehaviour
{
    public NetworkManager networkManager;
    public string networkaddress;

    public bool isServerBuild;


    //public DCP_UIDelay fadeLoadingIn;

    public float FadeRate;
    public Image image;
    public float targetAlpha;

    void Start()
    {
        networkManager.networkAddress = networkaddress;
        //targetAlpha = image.material.color.a;


        if (isServerBuild)
        {
            networkManager.StartHost();
            //fadeLoadingIn.StartDelay();
            StartCoroutine(Fade());
        }
        else
        {
            networkManager.StartClient();
        }

    }

    public override void OnStartClient() {

        // fadeLoadingIn.StartDelay();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.1f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        image.gameObject.SetActive(false);
    }
}
