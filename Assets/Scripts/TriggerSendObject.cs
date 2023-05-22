using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSendObject : MonoBehaviour
{
    
    public GameObject theObjectToSend;
    private GameObject _studentManager;
    private StudentManager _studentManagerScript;
    private ObjectManager _objectManager;
    private float _timeRemaining = 10;
    private bool _timerIsRunning;

    private bool _sendAlready;
    private string _sceneName;
    
    private void Awake()
    {
        _studentManager = GameObject.Find("GameManager");
        _studentManagerScript = _studentManager.GetComponent<StudentManager>();
        _objectManager = _studentManager.GetComponent<ObjectManager>();
        _sendAlready = false;
        _timerIsRunning = false;
        _sceneName = SceneManager.GetActiveScene().name;

    }
    // Start is called before the first frame update
    void Start()
    {
        
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
                _sendAlready = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_sendAlready)
        {
            Debug.LogError("YOU SEND THE THINGS!!");
            foreach (var student in _studentManagerScript._studentList)
            {
                if (student == null)
                {
                    Debug.LogError("there is no student");
                }
                
                Vector3 thePosition = new Vector3(student.transform.position.x, student.transform.position.y+0.5f, student.transform.position.z+0.8f);
                GameObject theObject = Instantiate(theObjectToSend, thePosition, Quaternion.Euler(0, 0,0));
                theObject.name = student.name;
                _objectManager.addObject(theObject);

                if (SceneManager.GetActiveScene().name == "Test2")
                {
                    GameObject[] miniStudents = GameObject.FindGameObjectsWithTag("miniStudents");

                    foreach (var ms in miniStudents)
                    {
                        if (student.name == ms.name)
                        {
                            Vector3 theMiniPosition = new Vector3(ms.transform.position.x,
                                ms.transform.position.y + 0.01f, ms.transform.position.z + 0.05f);
                            GameObject miniObject = Instantiate(theObjectToSend, theMiniPosition,
                                Quaternion.Euler(0, 0, 0));
                            miniObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.001f);
                            miniObject.name = ms.name;
                            miniObject.transform.parent = GameObject.Find("TheClassRoom").transform;
                            miniObject.GetComponent<Grabbable>().enabled = false;
                            _objectManager.addObject(miniObject);
                        }
                    }
                    
                }

            }
            _sendAlready = true;
            _timerIsRunning = true;
            _timeRemaining = 10;
            _studentManagerScript.ResetStudent();
            if (_sceneName == "Test2")
            {
                GameObject.Find("Students").GetComponent<ResetMinimap>().Reset();
            }
        }
    }
}
