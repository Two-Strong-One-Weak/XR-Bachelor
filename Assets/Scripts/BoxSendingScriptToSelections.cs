using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSendingScriptToSelections : MonoBehaviour
{
    private StudentManager _studentManagerScript;
    private float _waitTime = 1.5f;

    private void Awake()
    {
        _studentManagerScript = GameObject.Find("GameManager").gameObject.GetComponent<StudentManager>();

        if (_studentManagerScript == null)
        {
            Debug.LogError("Did not find the studentScripts");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var postItScript = other.transform.parent.parent.GetComponent<ClassRoomPostItScript>();
        if (other.transform.parent.parent.name == "PostItGrabClassRoom")
        {

            if (postItScript == null)
            {
                Debug.LogError("The Object Does not have a postItScript");
            }
            else
            {
                if (!postItScript.grabbed)
                {
                    //we do stuff
                    float timer = 0.0f;
                    while (timer < _waitTime)
                    {
                        timer += Time.deltaTime;
                    }
                    SendObject(other.transform.parent.parent.gameObject);
                    MoveToRetrieved(other.transform.parent.parent.gameObject);
                }
                else
                {
                    //Wait for it to be released
                }
            }
        }
        //maybe something about if its grabbed or not. And then a timer before it sends it
        //Then teleport it to the top of the box that sends stuff.
    }

    private void SendObject(GameObject objectToSend)
    {
        foreach (var studentSelected in _studentManagerScript._studentList)
        {
            Vector3 thePosition = new Vector3(studentSelected.transform.position.x, studentSelected.transform.position.y+1.8f, studentSelected.transform.position.z-0.4f);
            Instantiate(objectToSend, thePosition, studentSelected.transform.rotation);
        }
    }

    private void MoveToRetrieved(GameObject objectToMove)
    {
        objectToMove.transform.position = new Vector3(2.752f, 1.882f, -108.976f);
    }
}
