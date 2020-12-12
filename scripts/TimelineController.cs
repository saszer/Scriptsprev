using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

//created during multiverse development - sz.sahaj
//match name of your scene for restart
//attach timeline in inspector - mayhem!

public class TimelineController : MonoBehaviour
{
    public PlayableDirector mayhem;
  

    public void PlayNow()
    {
        mayhem.Play(); ;
    }

    public void PlayfromStart()
    {
        mayhem.time = 5;
        mayhem.Play();
    }

    public void Pause()
    {
        mayhem.Pause(); ;
    }
    public void RestartGame()
    {

        SceneManager.LoadScene("SampleScene");

    }
}
