using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandMenu : MonoBehaviour
{
    private GameObject _theHand;
    private Vector3 _handsPosition;
    public GameObject shareMenuObject;
    public GameObject SpawnMenuObject;
    public GameObject trashcanMenuObject;
    public GameObject fingerIconsObject;
    private float _moveAmountY = 0.12f;
    private float _moveAmountZ = 0.08f;
    
    
    private void Awake()
    {
        gameObject.SetActive(false);
        _theHand = GameObject.Find("LeftOVRHand");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = new Vector3(_theHand.transform.position.x, _theHand.transform.position.y + _moveAmountY,
                _theHand.transform.position.z+_moveAmountZ);
        }
    }
    
    public void ShareMenu()
    {
        if (!shareMenuObject.activeSelf)
        {
            shareMenuObject.SetActive(true);
            fingerIconsObject.SetActive(false);
        }
    }

    public void SpawnItem()
    {
        
    }

    public void TrashCan()
    {
        
    }

    public void BackInMenu()
    {
        //Should be better for now it's if statement and then switch for testing
        if (shareMenuObject.activeSelf)
        {
            shareMenuObject.SetActive(false);
            fingerIconsObject.SetActive(true);
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
    
    //Make wrist flicking to go back or something like that.
    
}
