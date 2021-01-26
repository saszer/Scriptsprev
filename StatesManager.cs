using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public GameObject[] states;
    public int currstate = 0;

    public Plant_LifeTimer plantlifetimer;

    public void Start()
    {
        currstate = 0;
    }
    private void Update()
    {
        /* switch (plantlifetimer.startingTime / plantlifetimer.currentTime)
         {
         case 1:
             currstate = 0;
             ChangeState();
                 break;

         case 2:
             currstate = 1;
             ChangeState();
             break;

         case 5:
             currstate = 2;
             ChangeState();
             break;

         default:
             currstate = 0;
             ChangeState();
             break;

         }
         */
        float statefloat = plantlifetimer.startingTime / plantlifetimer.currentTime;
        Debug.Log(statefloat);
        if (statefloat > 1f && statefloat < 1.5f)
        {
            Debug.Log("0");
            currstate = 0;
            ChangeState();
        }

        if (statefloat > 1.5f && statefloat < 5f)
        {
            Debug.Log("1");
            currstate = 1;
            ChangeState();
        }

        if (statefloat > 5)
        {
            Debug.Log("2");
            currstate = 2;
            ChangeState();
        }


    }

    void ChangeState()
    {
        Debug.Log("changestate");
        for(int i = 0; i< states.Length; i++)
        {
            states[i].SetActive(false);
            if(i == currstate)
            {
                states[i].SetActive(true);
            }
        }
    }
}
