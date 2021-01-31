using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//iterate through and open close
//sz.sahaj@embracingearth.space
public class InventoryPanelOpenClose : MonoBehaviour
{
    public GameObject[] inventorypanel;

    bool currentstate = false;
    public int index = 0;

    public void OpenClose()
    {
        if (index < inventorypanel.Length)
        {
            inventorypanel[index].SetActive(true);
            index++;
        }

        else
        {
            index = 0;
            for (int i = 0; i < inventorypanel.Length; i++) {
                inventorypanel[i].SetActive(false);
            }
        }
        
   

    }

}
