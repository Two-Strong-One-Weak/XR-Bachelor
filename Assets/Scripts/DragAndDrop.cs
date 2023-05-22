using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _holding;
    private GameObject _testCube;
    public GameObject _firstChild;
    public GameObject _secondChild;
    
    // Start is called before the first frame update
    void Awake()
    {
        _testCube = GameObject.Find("TestCube");
        _holding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_holding && other.gameObject == _firstChild)
        {
           Renderer render = _firstChild.GetComponent<Renderer>();
           render.material.color = new Color(0, 0, 255, 1);
        }
        else
        {
            //Error handling
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Renderer render = _firstChild.GetComponent<Renderer>();
        render.material.color = new Color(0, 0, 0, 1);
    }

    //NOTE: Gotta check how this actually works and make it so you can drop it in here.
    private void OnTriggerStay(Collider other)
    {
        if (!_holding && other.gameObject == _testCube)
        {
            //symbolize that it would send it.
            Renderer render = _firstChild.GetComponent<Renderer>();
            render.material.color = new Color(0, 255, 0, 1);
        }
        else
        {
            //Error handling
        }
    }

    public void IsGrabbed()
    {
        gameObject.GetComponent<Outline>().enabled = true;
        _holding = true;
        Logger.Instance.LogInfo("You grabbed the postIT!");
        _firstChild.SetActive(true);
        _secondChild.SetActive(false);
        
    }

    public void NotGrabbed()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        _holding = false;
        _firstChild.SetActive(true);
        _secondChild.SetActive(false);
    }
}
