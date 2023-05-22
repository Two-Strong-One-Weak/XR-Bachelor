using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShareMenu : MonoBehaviour
{
    private GameObject _theHand;
    private Vector3 _handPosition;
    private float _moveAmount = 0.0f;
    private float _moveAmountY = 0.15f;
    private float _moveAmountZ = 0.1f;


    private void Awake()
    {
        gameObject.SetActive(false);
        _theHand = GameObject.Find("LeftOVRHand");
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = new Vector3(_theHand.transform.position.x-_moveAmount, _theHand.transform.position.y+_moveAmountY, _theHand.transform.position.z-_moveAmountZ);

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
        Debug.LogError("YOU ARE SHOWING IT!!");
    }


    private void UpdateLocation()
    {
        transform.position = new Vector3(_theHand.transform.position.x-_moveAmount, _theHand.transform.position.y+_moveAmountY, _theHand.transform.position.z-_moveAmountZ);
    }
}
