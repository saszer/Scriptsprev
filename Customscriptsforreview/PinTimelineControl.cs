using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PinTimelineControl : MonoBehaviour
{
    public PlayableDirector mayhem;
    // Start is called before the first frame update


    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == "ParticleCube(Clone)")
        {
            Debug.Log("Awakened");
            mayhem.Play();
           // Destroy(collide); done in article prefab

        }
    }
}
