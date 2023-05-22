using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmShareMenu : MonoBehaviour
{

    private GameObject _theHand;
    private Vector3 _handPosition;
    private float _moveAmount = 0.08f;


    private void Awake()
    {
        gameObject.SetActive(false);
        _theHand = GameObject.Find("LeftOVRHand");
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = new Vector3(_theHand.transform.position.x, _theHand.transform.position.y + _moveAmount, _theHand.transform.position.z);

            /*float wristRotation = Mathf.Clamp(_theHand.transform.rotation.z, 290f, 350f);
            transform.rotation = Quaternion.Euler(_theHand.transform.rotation.eulerAngles.x, _theHand.transform.rotation.eulerAngles.y, wristRotation);*/

            
            //Not sure if this is the way. But lets try.
            //transform.rotation = _theHand.transform.rotation;
        }
    }

    public void HideOnClose()
    {
        gameObject.SetActive(false);
    }

    public void ShowOnOpen()
    {
        UpdateLocation();
        gameObject.SetActive(true);
    }


    private void UpdateLocation()
    {
        transform.position = new Vector3(_theHand.transform.position.x, _theHand.transform.position.y + _moveAmount, _theHand.transform.position.z);
    }
}
