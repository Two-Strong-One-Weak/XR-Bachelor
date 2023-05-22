using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSendScript : MonoBehaviour
{
    private StudentManager _studentManagerScript;
    private bool _hasBeenGrabbed;
    public GameObject thePrefab;
    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {
        _studentManagerScript = GameObject.Find("GameManager").GetComponent<StudentManager>();
        _hasBeenGrabbed = false;
    }
    
    public void IsGrabbed()
    {
        Debug.LogError("YOU GRABBED IT!");
        _hasBeenGrabbed = true;
    }

    public void NotGrabbed()
    {
        
        Debug.LogError("YOU LET GO OF IT!");
        if (_hasBeenGrabbed)
        {
            if (_studentManagerScript._studentList.Count > 0)
            {
                Debug.LogError("YOU SEND THE THINGS!!");
                foreach (var student in _studentManagerScript._studentList)
                {
                    if (student == null)
                    {
                        Debug.LogError("there is no student");
                    }
                    
                    Vector3 thePosition = new Vector3(student.transform.position.x, student.transform.position.y+1.8f, student.transform.position.z+0.4f);
                    Instantiate(thePrefab, thePosition, student.transform.rotation);
                    _studentManagerScript.RemoveStudent(student);
                }
                _hasBeenGrabbed = false;
            }
        }
    }
}
