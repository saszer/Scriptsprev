using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartDestroySequence : MonoBehaviour
{
    UnityEvent EventToDoBeforeDestroy;

    [Tooltip("This will be time it takes Foor your event, Before this GameObject Is destroyed")]
    public float duration;
    public void Destroying()
    {
        StartCoroutine(Destroyin());
    }

    IEnumerator Destroyin()
    {

        EventToDoBeforeDestroy.Invoke();
        yield return new WaitForSeconds(duration);   //Wait
        Destroy(this.gameObject);
    }
}
