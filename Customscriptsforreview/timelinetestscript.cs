using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelinetestscript : MonoBehaviour
{
    public PlayableDirector mayhem;
    

    // Start is called before the first frame update
    void OnEnable()
    {
        //mayhem.Pause();
        mayhem.Pause();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
