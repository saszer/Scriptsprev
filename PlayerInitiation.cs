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
    private Behaviour[] ComponentstoDisable;

    public override void OnStartAuthority()
    {
        //Components to Disable if LocalPlayer
        for(int i =0; i < ComponentstoDisable.Length; i++)
        {
            ComponentstoDisable[i].enabled = true;
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
    private void Awake()
    {
        for (int i = 0; i < ComponentstoDisable.Length; i++)
        {
            ComponentstoDisable[i].enabled = false;
        }
    }
    
}
