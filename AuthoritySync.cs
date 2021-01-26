using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AuthoritySync : NetworkBehaviour
{
   public Player_Properties playerproperties;
    public void PlayerDatatoServerandLocal(PlayerPropJson recievedplayerproperties) //mainly used for first initialise to read from database and sync to server.
    {
        playerproperties.carbonfootprint = recievedplayerproperties.carbonfootprint;
        playerproperties.username = recievedplayerproperties.username;

        CmdSetProperties(recievedplayerproperties.username, recievedplayerproperties.carbonfootprint);
    }

    [Command]
    void CmdSetProperties(string username, float score)
    {
        playerproperties.username = username;
        playerproperties.carbonfootprint = score;
    }

    public void PlayerPropertiesToServer()
    {
        CmdSetProperties(playerproperties.username, playerproperties.carbonfootprint);
    }


    public void Start()
    {
        playerproperties = GetComponent<Player_Properties>();
    }


    public void WaterMe(Plant_LifeTimer plantlifetimer)
    {
        CmdWaterMe(plantlifetimer);
    }
    [Command]
    void CmdWaterMe(Plant_LifeTimer plant_lifetimer)
    {
        plant_lifetimer.Water();
    }



    public void ShovelMe(GameObject Plant)
    {
        CmdShovelMe(Plant);
    }
    [Command]
    void CmdShovelMe(GameObject Plant)
    {
        Destroy(Plant);
    }

}
