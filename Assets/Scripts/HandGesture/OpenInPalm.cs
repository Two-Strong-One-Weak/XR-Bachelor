using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInPalm : MonoBehaviour
{

    private GameObject _theHand;
    private Vector3 _handsPosition;
    private Vector3 _thisPosition;
    private float _moveAmountY = 0.18f;
    private float _moveAmountZ = 0.08f;

    
    private void Awake()
    {
        gameObject.SetActive(false);
        _theHand = GameObject.Find("LeftOVRHand");
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = new Vector3(_theHand.transform.position.x, _theHand.transform.position.y + _moveAmountY,
                _theHand.transform.position.z+_moveAmountZ);
        }
    }

    public void ShowOnOpen()
    {
        UpdateLocation();
        gameObject.SetActive(true);
        Logger.Instance.LogInfo("Opened your hand");
    }

    public void HideOnClose()
    {
        gameObject.SetActive(false);
        Logger.Instance.LogInfo("Closed your hand");

    }

    private void UpdateLocation()
    {
        Logger.Instance.LogInfo($"Cubes position is -> {transform.position}");
        Logger.Instance.LogInfo($"Hand position is -> {_theHand.transform.position}");
        transform.position = new Vector3(_theHand.transform.position.x, _theHand.transform.position.y+_moveAmountY,
            _theHand.transform.position.z+ _moveAmountZ);

    }
}
