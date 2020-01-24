using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NVIDIA.Flex
{
    public class Unableaftersometime : MonoBehaviour
    {

      //  public GameObject Object1;
      //  public string scr;// your secound script name
        void OnEnable()
        {
            //On game start the script on GO1 is turned of an a couroutine is started

         //   (Object1.GetComponent(scr) as MonoBehaviour).enabled = false;
            StartCoroutine(Example());

            //Object1.AddComponent("FlexFluidRenderer");

            


        }
        IEnumerator Example()
        {
            yield return new WaitForSeconds(11); //After Four Seconds
            var myScript = gameObject.AddComponent<FlexFluidRenderer>();
        }
    }


}


