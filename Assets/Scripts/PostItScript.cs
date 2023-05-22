using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PostItScript : MonoBehaviour
{
    
    //Note Get owner and of this game object maybe?
    private List<Player> playerList;
    private GameObject _postItPrefab;    
    public GameObject _firstChild;
    public GameObject _secondChild;
    public bool _grabbed;


    private void Awake()
    {
        GameObject handMenu = GameObject.Find("HandMenu");
        gameObject.GetComponent<Outline>().enabled = false;
        _grabbed = false;
        /*  _firstChild = handMenu.transform.GetChild(0).gameObject;
          _secondChild = handMenu.transform.GetChild(1).gameObject;
          
          _firstChild.SetActive(true);
          _secondChild.SetActive(false);*/
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //IsGrabbed();
    }

    //Also the PostIt does not spawn on the network for some reason......
    public void Spawner()
    {
       _postItPrefab = PhotonNetwork.Instantiate("PostIt", new Vector3(0, 1f, 0), Quaternion.identity);
       //Instantiate(this, new Vector3(0, 1f, 0), Quaternion.identity);
    }
    
    void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        info.Sender.TagObject = this;
    }

    
    //NOTE: you get your own position atm you need to fix so its the other players
    public void Send()
    {
        //playerList = PhotonNetwork.PlayerList
        Logger.Instance.LogInfo($"PlayerCount: {PhotonNetwork.PlayerList.Length}");
        Logger.Instance.LogInfo($"PlayerCountThatIsNotYou: {PhotonNetwork.PlayerListOthers.Length}");
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Logger.Instance.LogInfo($"Player ActorNumber: {player.ActorNumber}");
            Logger.Instance.LogInfo($"Player ID: {player.UserId} Player Name: {player.NickName}");

            if (!player.IsLocal)
            {
                
                //Logger.Instance.LogInfo($"Player ID: {player.UserId} Player Name: {player.NickName}");
                //Logger.Instance.LogInfo($"Player ActorNumber: {player.ActorNumber}");
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                Debug.Log(players);
                foreach (GameObject p in players)
                {
                        //Transform aHead = transform.Find("Head");
                        //Logger.Instance.LogInfo($"head is:{aHead.transform.position}");
                        Logger.Instance.LogInfo($"OtherPlayer ActorNumber:{player.GetNext().ActorNumber}");

                        Transform otherPlayer = p.GetComponentInChildren<PhotonTransformView>().transform;
                        Logger.Instance.LogInfo($"P is:{p}");
                        Logger.Instance.LogInfo($"Player Position: {otherPlayer.transform.position}");
                        _postItPrefab.transform.position = new Vector3(otherPlayer.transform.position.x, otherPlayer.transform.position.y,
                            otherPlayer.transform.position.z+0.2f);
                        Logger.Instance.LogInfo($"PostIT Position: {_postItPrefab.transform.position}");
                } 
            }
            else
            {
                Debug.Log("You are in the else!");
            }
        }
        
        
    }

    public void IsGrabbed()
    {
        gameObject.GetComponent<Outline>().enabled = true;

        Logger.Instance.LogInfo("You grabbed the postIT!");
        _grabbed = true;
        _firstChild.SetActive(false);
        _secondChild.SetActive(true);

    }

    public void NotGrabbed()
    {
        gameObject.GetComponent<Outline>().enabled = false;

        _grabbed = false;
        
       _firstChild.SetActive(true);
       _secondChild.SetActive(false);

    }
    
}
