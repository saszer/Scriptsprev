
using UnityEngine;
 using System.Collections;
 
 public class OnandOff : MonoBehaviour {
   public float sec = 500f;
   
     void Start()
     {
         if (gameObject.activeInHierarchy)
             gameObject.GetComponent<Renderer>().enabled = false;
 
         StartCoroutine(LateCall());
     }
 
     IEnumerator LateCall()
     {
 
         yield return new WaitForSeconds(sec);
 
         gameObject.GetComponent<Renderer>().enabled = true;
         //Do Function here...
     }
 }


