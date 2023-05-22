using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionScript : MonoBehaviour
{
    public bool _selected;
    private GameObject _studentManager;
    private StudentManager _studentManagerScript;
    public GameObject thePrefab;
    private void Awake()
    {
        _selected = false;
        gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        _studentManager = GameObject.Find("GameManager");
        _studentManagerScript = _studentManager.GetComponent<StudentManager>();
    }

    public void Hover()
    {
        gameObject.SetActive(true);
    }

    public void UnHover()
    {
        if (!_selected)
        {
            gameObject.SetActive(false);
        }
    }

    public void Selected()
    {
        if (gameObject.transform.parent.gameObject.CompareTag("Students"))
        {
            if (_selected)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
                _selected = false;
                _studentManagerScript.RemoveStudent(gameObject.transform.parent.gameObject);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 1);
                _selected = true;
                _studentManagerScript.AddStudent(gameObject.transform.parent.gameObject);

            }
        }
        else
        {
            //More Checks and stuff here in the future.
            Debug.LogError("Should send call the send method");
            SendObject();
            
        }
    }

    public void SendObject()
    {
        foreach (var student in _studentManagerScript._studentList)
        {
            Vector3 thePosition = new Vector3(student.transform.position.x, student.transform.position.y+1.8f, student.transform.position.z-0.4f);
            Instantiate(thePrefab, thePosition, student.transform.rotation);
        }
    }
}
