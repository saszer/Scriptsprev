using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class boomtouch : MonoBehaviour
{
    public PlayableDirector mayhem;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GameObject" || other.gameObject.name == "R_Palm")
        {
            Debug.Log("Awakened");
            mayhem.Play();
        }

    }
    public void Start()
    {
        
    }
}
