using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureSendOption : MonoBehaviour
{

    public bool _hasBeenSent;

    private string _name = "PostItPlaceOnShare";
    private string _postItColor;
    
    private GameObject _studentToSentTo;
    private StudentManager _studentManager;
    public GameObject theYellowPrefab;
    public GameObject theRedPrefab;
    public GameObject theBluePrefab;
    private ObjectManager _objectManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _hasBeenSent = false;
        _studentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();
        _objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_hasBeenSent && other.name.Contains(_name))
        {
            _postItColor = other.name;
            
            foreach (var student in _studentManager._listOfAllStudents)
            {
                if (gameObject.name == student.name)
                {
                    _studentToSentTo = student;
                }
            }
            
            Send();
            
            //Maybe make it so this reset after a time with a timer.
            _hasBeenSent = true;
        }
    }

    private void Send()
    {
        if (_studentToSentTo == null)
        {
            Debug.LogError("there is no student");
        }
        
        //How to fix color sending, Make if that checks on the coliders name and then instantiate that here in the send

        if (_postItColor == "PostItPlaceOnShare")
        {
            Vector3 thePosition = new Vector3(_studentToSentTo.transform.position.x, _studentToSentTo.transform.position.y+0.5f, _studentToSentTo.transform.position.z+0.8f);
           GameObject theYellowObject = Instantiate(theYellowPrefab, thePosition, Quaternion.Euler(0, 0,0));
           _objectManager.addObject(theYellowObject);
           
        } else if (_postItColor == "PostItPlaceOnShareRed")
        {
            Vector3 thePosition = new Vector3(_studentToSentTo.transform.position.x, _studentToSentTo.transform.position.y+0.5f, _studentToSentTo.transform.position.z+0.8f);
            GameObject theRedObject = Instantiate(theRedPrefab, thePosition, Quaternion.Euler(0, 0,0));
            _objectManager.addObject(theRedObject);
        } else if (_postItColor == "PostItPlaceOnShareBlue")
        {
            Vector3 thePosition = new Vector3(_studentToSentTo.transform.position.x, _studentToSentTo.transform.position.y+0.5f, _studentToSentTo.transform.position.z+0.8f);
            GameObject theBlueObject = Instantiate(theBluePrefab, thePosition, Quaternion.Euler(0, 0,0));
            _objectManager.addObject(theBlueObject);
        }
        else
        {
            //nothing
        }
        
        
    }
}
