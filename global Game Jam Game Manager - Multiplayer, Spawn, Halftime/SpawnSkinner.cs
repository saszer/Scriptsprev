using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
//sz.sahaj@gmail.com

public class SpawnSkinner : NetworkBehaviour
{
    public player_properties playerproperties;
    public GameObject GhostSkin;
    public GameObject HumanSkin;

    GameObject tospawn;
    GameObject instantiatedskin;
    //public Transform[] spawntransforms;
    Vector3 selectedspawn;
    bool firstround = true;
    int index;

    public Vector3 Team_A_TransFormPoint;
    public Vector3 Team_B_TransFormPoint;
    Quaternion rotation;
    private void Start()
    {
        CmdFirstSpawn();
        firstround = true;

        /*
        spawntransforms = GameObject.Find("StartPositions").GetComponentsInChildren<Transform>();
        index = Random.Range(0, spawntransforms.Length);
        selectedspawn = spawntransforms[index].transform.position;
        */
    }

    [Command]
    void CmdFirstSpawn()
    {
        //selectedspawn = spawntransforms[index];

        if (playerproperties.teamID == 0){
            selectedspawn = Team_A_TransFormPoint;
        }
        else
        {
            selectedspawn = Team_B_TransFormPoint;
        }

        if (instantiatedskin != null)
        {
            Destroy(instantiatedskin);
        }

        if (playerproperties.teamID == 0) //switch team
        {
            tospawn = GhostSkin;
        }
        else
        {
            tospawn = HumanSkin;
        }

        instantiatedskin = (GameObject)Instantiate(tospawn, selectedspawn, Quaternion.identity);
        NetworkServer.Spawn(instantiatedskin, connectionToClient);

    }

    [Command]
    void CmdSpawn()
    {       
        if (playerproperties.teamID == 0) //switch team
        {
            tospawn = GhostSkin;
        }
        else
        {
            tospawn = HumanSkin;
        }

        selectedspawn = instantiatedskin.transform.position;
        Vector3 newRotation = new Vector3(instantiatedskin.transform.localEulerAngles.x, instantiatedskin.transform.localEulerAngles.y, instantiatedskin.transform.localEulerAngles.z);

        instantiatedskin = (GameObject)Instantiate(tospawn, selectedspawn, Quaternion.Euler(newRotation));
        //GameObject owner = this.gameObject;
        NetworkServer.Spawn(instantiatedskin, connectionToClient);
    }

    public void SwitchSkins()  // CALL AT HALFTIME OR ANYTIME TO SWITCH AND SPAWN ON SERVER AND ALL!
    {
        CmdCallServer();
    }

    [Command]
    void CmdCallServer()
    {
        DestroyOldSkin();
    }

    void DestroyOldSkin()
    {
        Destroy(instantiatedskin);
        switchTeamId();
    }

    void switchTeamId()
    {
        if (playerproperties.teamID == 0)
        {
            playerproperties.teamID = 1;
        }
        else
        {
            playerproperties.teamID = 0;
        }

        CmdSpawn();
    }
}
