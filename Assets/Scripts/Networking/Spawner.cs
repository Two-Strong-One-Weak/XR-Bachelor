using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    
    private PhotonView _photonView;
    private GameObject _theCube;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0,10.0f,0);
    }

    public void TheSpawner()
    {
        Logger.Instance.LogInfo("Spawn the cube!!");
        _theCube = PhotonNetwork.Instantiate("TheRedCube", new Vector3(0.1f, 2f, 0), Quaternion.identity);
    }

    void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        info.Sender.TagObject = this;
    }

    public void TheDestroyer()
    {
        Logger.Instance.LogInfo("Deleted the Cube");
        PhotonNetwork.Destroy(_theCube);
    }
    
    void MapPosition(Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;

    }
}
