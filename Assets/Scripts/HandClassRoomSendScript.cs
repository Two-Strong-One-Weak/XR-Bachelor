using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClassRoomSendScript : MonoBehaviour
{
    private Renderer _theRender;

    private StudentManager _studentManager;

    private GameObject _theStudent;

    private bool _selected;
    private float _timeRemaining = 20;
    private bool _timerIsRunning;

    private bool _selectedAlready;
    // Start is called before the first frame update
    void Start()
    {
        _theRender = GetComponent<Renderer>();
        _studentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();
        _selected = false;
        _selectedAlready = false;
        _timerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.LogError("Time has run out!");
                _timeRemaining = 0;
                _timerIsRunning = false;
                _selectedAlready = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightHandCollider")
        {
            if(!_selected && !_selectedAlready)
           {
                    _theRender.material.color = Color.green;
                    _selected = true;
                    _selectedAlready = true;
                    _timeRemaining = 20;
                    foreach (var student in _studentManager._listOfAllStudents)
                    {
                        if (gameObject.name == student.name)
                        {
                            _theStudent = student;
                        }
                    }

                    if (_theStudent != null)
                    {
                        _studentManager.AddStudent(_theStudent);
                        GameObject theArrow = _theStudent.transform.Find("Arrow").gameObject;
                        Renderer arrowRenderer = theArrow.GetComponent<Renderer>();
                        if (arrowRenderer == null)
                        {
                            Debug.LogError("You did not get the renderer of the arrow!!");
                        }
                        else
                        {
                            theArrow.SetActive(true);
                            arrowRenderer.material.color = Color.green;
                        }
                    
                    }
           }
           else
           {
                _theRender.material.color = Color.white;
                _selected = false;
                _selectedAlready = false;
                if (_theStudent != null)
                {
                    _theStudent.transform.Find("Arrow").gameObject.SetActive(false);
                    _studentManager.RemoveStudent(_theStudent);
                }
           }
        }
    }

    public void ResetPerson()
    {
        _selected = false;
        _theRender.material.color = Color.white;
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}
