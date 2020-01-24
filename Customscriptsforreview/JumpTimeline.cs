using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class JumpTimeline : MonoBehaviour
{
    public PlayableDirector mayhem;
    public UnityEvent m_MyEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        { Debug.Log ("Reborn") ;

            mayhem.time = 420;
            mayhem.Play();
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            Debug.Log("5");

            mayhem.time = 246;
            mayhem.Play();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log("4");

            mayhem.time = 155;
            mayhem.Play();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("3");

            mayhem.time = 101;
            mayhem.Play();
        }

        if (Input.GetKey("p"))
        {
            Debug.Log("Play");

            mayhem.Play();
        }

        if (Input.GetKey("o"))
        {
            Debug.Log("Play");

            mayhem.Play();
        }

        if (Input.GetKey("r"))
        { m_MyEvent.Invoke();
        }

    }
}
