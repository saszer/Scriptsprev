using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mapbox.Unity.Location;
using Mapbox.Examples;

public class PlayerInitiation : NetworkBehaviour
{
    public MeshRenderer[] meshrenderes;

    [SerializeField,Tooltip("Components to Disable if LocalPlayer")]
    private Behaviour[] ComponentstoEnable;

    public override void OnStartAuthority()
    {
        //Components to Disable if LocalPlayer
        for(int i =0; i < ComponentstoEnable.Length; i++)
        {
            ComponentstoEnable[i].enabled = true;
        }

        //Change Color if its Local Player
        for (int i =0; i < meshrenderes.Length; i++)
        {
            meshrenderes[i].material.color = Color.white;
        }

        //Change Name to Local to access easily
        this.gameObject.name = ("Local");

    }

    
    //awake is called before start
    private void Start()
    {
        for (int i = 0; i < ComponentstoEnable.Length; i++)
        {
            ComponentstoEnable[i].enabled = false;
        }
    }
    
}
