using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class RestartNamaste : MonoBehaviour
{
    // Item we want to spawn
    public UnityEvent m_MyEvent;
    // How long the player needs to stay at location
    public float timerCountDown = 5.0f;
    // Is the player currently at location
    bool isPlayerColliding = false;

    void Update()
    {
        // Collision timer
        if (isPlayerColliding == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown < 0)
            {
                timerCountDown = 0;
            }
        }

        Debug.Log(isPlayerColliding);
    }

    // Start the collision timer when player enters
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "R_Palm")
        {
            Debug.Log("Namastaying");
            isPlayerColliding = true;
        }

    }
    // Check if the player is still at location, if they are spawn our secret item
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "R_Palm" && isPlayerColliding == true)
        {
            Debug.Log("Countdown not done yet");
            if (timerCountDown <= 0)
            {
                Debug.Log("Restarting...");
                m_MyEvent.Invoke();
            }

        }
    }
    // If the player is not colliding reset our timer
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "R_Palm")
        {
            Debug.Log("Namaste Exited");
            isPlayerColliding = false;
        }
    }
}
