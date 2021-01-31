using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;
using TMPro;
//sz.sahaj@embracingearth.space
/// <summary>
/// Runs through Rounds, Events on HalfTime, Round Complete, Game Complete etc, Switch Side Of Team In Between. 
/// Progress Bar for Round Completeion, Client - Server Sync, Multiplayer - unity mirror.
/// </summary>

public class GameManager : NetworkBehaviour
{
    public float GameTime;

    public UnityEvent OnHalfTime;
    public UnityEvent OnRoundOver;
    public UnityEvent OnGameOver;
    public UnityEvent SwitchSides;
    public Image _ProgressBar;

    public int NumberOfRounds;
    [SyncVar(hook = nameof(OnNumofRoundChange))] int NumberOfRoundsSync;

    float HalfTime;
    NetworkManager networkmanager;
    [SyncVar(hook =nameof(OnCurrRoundChange))]int currround;
    public Text currentRoundNumberText;
    public TextMeshProUGUI RoundNum;
    public Text NumOfRoundsText;
    [SyncVar(hook =nameof(OPdateOnclient))] float currRoundProgress;
    void Start()
    {
        networkmanager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerExt>();
        _ProgressBar.fillAmount = 0;
        currround = 1;
        currentRoundNumberText.text = currround.ToString();
        NumberOfRoundsSync = NumberOfRounds; //ToSync
        HalfTime = GameTime / 2;

        //Run Timer On Server (Synced to Clients by SyncVar CurrGametime
        if (!isServer)
            return;
        GameRunner();

    }

    void GameRunner()
    {
        if(currround  < NumberOfRounds +1)
        {
            if(currround == (NumberOfRounds / 2) + 1 )
            {
                SkinSwitchandSpawn();
                SwitchSides.Invoke();
            }
            RunRound();
        }
        else
        {
            RpcGameOver(); 
        }

    }

    public void returntoLobby() //call from a button
    {
        CmdreturntoLobby();
    }

   // [Command]
    void CmdreturntoLobby()
    {
        NetworkRoomManagerExt.singleton.ServerChangeScene("RoomScene");
    }

    void RunRound()
    {
        Debug.Log("GOGOGO");
        currRoundProgress = 0;
        StartCoroutine(ZeroToHalftim());

    }

    IEnumerator ZeroToHalftim()
    {
        _ProgressBar.fillAmount = 0;
        float time = 0;
        float startValue = 0;
        float timetocomplete = HalfTime;
        while (time < timetocomplete)
        {
            _ProgressBar.fillAmount = (Mathf.Lerp(startValue, 0.5f, time / timetocomplete));
            currRoundProgress = _ProgressBar.fillAmount;
            time += Time.deltaTime;
            yield return null;
        }

        Debug.Log("HalfTime");
        RpcHalfTimeEvents();
        //SkinSwitchandSpawn();
        StartCoroutine(halftimeToEnd());

    }

    public GameObject[] Players;
    void SkinSwitchandSpawn()
    {
        Players = GameObject.FindGameObjectsWithTag("GamePlayer");

        foreach (GameObject player in Players)
        {
            player.GetComponent<SpawnSkinner>().SwitchSkins();
        }
    }

    IEnumerator halftimeToEnd()
    {
        Debug.Log("SecondHalf");

        float time = 0;
        float startValue = _ProgressBar.fillAmount;
        float timetocomplete = HalfTime;
        while (time < timetocomplete)
        {
            _ProgressBar.fillAmount = (Mathf.Lerp(startValue, 1, time / timetocomplete));
            currRoundProgress = _ProgressBar.fillAmount;
            time += Time.deltaTime;
            yield return null;
        }

        Debug.Log("FullTime");
        RpcRoundOver();
        
        currround++;
        GameRunner();
    }



    //ServerToclientCalls

    [ClientRpc]
    void RpcHalfTimeEvents()
    {
        OnHalfTime.Invoke();
    }

    [ClientRpc]
    void RpcRoundOver()
    {
        OnRoundOver.Invoke();
    }

    [ClientRpc]
    void RpcGameOver()
    {
        OnGameOver.Invoke();
        Cursor.lockState = CursorLockMode.None;
    }

    void OPdateOnclient(float oldvalue, float currRoundProgress)
    {
        _ProgressBar.fillAmount = currRoundProgress;
    }

    void OnCurrRoundChange(int oldvalue, int currround)
    {
        if (currround != NumberOfRounds+1)
        {
            currentRoundNumberText.text = currround.ToString();
            RoundNum.text = currround.ToString();
        }
    }

    void OnNumofRoundChange(int oldvalue, int numofround)
    {
        NumOfRoundsText.text = numofround.ToString();
    }

}
