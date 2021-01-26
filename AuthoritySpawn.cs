using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AuthoritySpawn : NetworkBehaviour
{

    PlantList plantlist;

    private void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        plantlist = GameManager.GetComponent<PlantList>();
    }
    

    public void Spawn(int playerchose, Vector3 position)
    {
        CmdSpawnOnServer(playerchose, position);
    }

    [Command]
    void CmdSpawnOnServer(int playerchose, Vector3 position)
    {
        GameObject obj = (GameObject)Instantiate(plantlist.PlantPrefabs[playerchose], position, Quaternion.identity);
        NetworkServer.Spawn(obj);
    }
}
