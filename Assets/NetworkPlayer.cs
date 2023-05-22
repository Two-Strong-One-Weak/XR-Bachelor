using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    
    private PhotonView _photonView;
    
    //(localHead position and rotation) = (networkHead position and rotation)
   /* //Head
    private GameObject localHead;
    public GameObject networkHead;
    //Left Hand
    private GameObject localLeftHand;
    public GameObject networkLeftHand;
    //Right Hand
    private GameObject localRightHand;
    public GameObject networkRightHand; */

   public Transform head;
   public Transform leftHand;
   public Transform rightHand;

   public Animator leftHandAnimator;
   public Animator rightHandAnimator;

   private Transform _headRig;
   private Transform _leftHandRig;
   private Transform _rightHandRig;


   public void Start()
   {
       _photonView = GetComponent<PhotonView>();
       OVRCameraRig rig = FindObjectOfType<OVRCameraRig>();
       _headRig = rig.transform.Find("TrackingSpace/CenterEyeAnchor");
       _leftHandRig = rig.transform.Find("TrackingSpace/LeftHandAnchor");
       _rightHandRig = rig.transform.Find("TrackingSpace/RightHandAnchor");

       if (_photonView.IsMine)
       {
           foreach (var item in GetComponentsInChildren<Renderer>())
           {
               item.enabled = false;
           }
       }
   }

   // Start is called before the first frame update
    private void Awake()
    {
        /*if (localHead == null)
        {
            localHead = GameObject.FindWithTag("Local Head");
        }

        if (localLeftHand == null)
        {
            localLeftHand = GameObject.FindWithTag("Local Left Hand");
        }

        if (localRightHand == null)
        {
            localRightHand = GameObject.FindWithTag("Local Right Hand");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine)
        {
            MapPosition(head, _headRig);
            MapPosition(leftHand, _leftHandRig);
            MapPosition(rightHand, _rightHandRig);
            
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }

       /* networkHead.transform.position = localHead.transform.position;
        networkHead.transform.rotation = localHead.transform.rotation;

        networkLeftHand.transform.position = localLeftHand.transform.position;
        networkLeftHand.transform.rotation = localLeftHand.transform.rotation;

        networkRightHand.transform.position = localRightHand.transform.position;
        networkRightHand.transform.rotation = localRightHand.transform.rotation; */

    }
    
    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
       
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;

    }
}
