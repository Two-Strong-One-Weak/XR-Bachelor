using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectIntoUIElement : MonoBehaviour
{

    private StudentManager _studentManagerScript;

    public GameObject thePrefab;
    // Start is called before the first frame update
    void Start()
    {
        _studentManagerScript = GameObject.Find("GameManager").GetComponent<StudentManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PostItGrabIntoMenu")
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
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PostItGrabIntoMenu")
        {
            Debug.LogError("The POST IT LEFT THE SEND AREA!");
        }
    }
}
