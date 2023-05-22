using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    /// <summary>
    /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
    /// </summary>
    [Tooltip(
        "The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    [Tooltip("The UI Panel let the user enter name and connect")] [SerializeField]
    private GameObject controlPanel;

    [Tooltip("The UI Label to inform user that the connection is in progress")] [SerializeField]
    private GameObject progressLabel;

    private bool isConnecting;

    #endregion
    
    #region Private Fields

    /// This client's version number. Users are separated from each other by gameversion
    private string gameVersion = "1";
    #endregion
    
    #region MonoBehaviour CallBacks

    void Awake()
    {
        
        // this makes sure we can use PhotonNetwork.LoadLevel() on master and other clients
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void Start()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }
    
    #endregion

    #region MonoBehaviourPunCallBacks CallBacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");

        if (isConnecting)
        { 
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        isConnecting = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN basics Tutorial/Launcher: OnJoinRandomFailed() was called by PUN. No random room found");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayersPerRoom});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We loaded the 'Room for 1'");
            
            PhotonNetwork.LoadLevel("Room for 1");
        }
        
    }

    #endregion


    #region Public Methods

    /// <summary>
    /// Start the connection process
    /// - If already connected, we attempt joining a random room
    /// - If not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a random room. If it fails, we get notified
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Service
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
        
        
    }
    
    

    #endregion
}
