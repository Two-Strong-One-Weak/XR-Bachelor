using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendObject : MonoBehaviour
{
    public GameObject theObjectToSend;
    private GameObject _studentManager;
    private StudentManager _studentManagerScript;

    private void Awake()
    {
        _studentManager = GameObject.Find("GameManager");
        _studentManagerScript = _studentManager.GetComponent<StudentManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Send()
    {
        
        Debug.LogError("YOU SEND THE THINGS!!");
        foreach (var student in _studentManagerScript._studentList)
        {
            if (student == null)
            {
                Debug.LogError("there is no student");
            }
            
            Vector3 thePosition = new Vector3(student.transform.position.x, student.transform.position.y, student.transform.position.z+2f);
            Instantiate(theObjectToSend, thePosition, Quaternion.Euler(0,0,0));
        }
    }
}
