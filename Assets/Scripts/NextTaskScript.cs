using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextTaskScript : MonoBehaviour
{

    public GameObject groupItems;

    private Button _theButton;
    private GameObject[] _theClones;
    private ObjectManager _theObjectManager;
    private PaticipantManager _paticipantManager;
    private StudentManager _studentManager;
    private int _taskCounter;
    private int _theParticipantNumber;
    private TMP_Text _textToEdit;
    private string[] _textArray;
    
    private float _timeRemaining = 4;
    private bool _timerIsRunning;

    private bool _allowedToPress;
    private string _sceneName;
    
    
    //Connect to a TaskScript Manager that has the arrays. So we know if it works.
    
    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        _allowedToPress = true;
        _timerIsRunning = false;
        _textArray = new[] { "Share to one", "Share to four", "Share to all", "Share to a Group" };
        _taskCounter = 1;
        _theButton = gameObject.GetComponent<Button>();
        if (_theButton == null)
        {
            Debug.LogError("You did not get the button");
        }
        _theButton.onClick.AddListener(TaskHandling);
        _theObjectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        if (_theObjectManager == null)
        {
            Debug.LogError("The Object manager is not found!");
        }
        _paticipantManager = GameObject.Find("PaticipantManager").GetComponent<PaticipantManager>();
        if (_paticipantManager == null)
        {
            Debug.LogError("The Object manager is not found!");
        }

        _theParticipantNumber = _paticipantManager.getNumber();

        _studentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();

        
        SetTextBasedONSceneName();
    }

    private void Update()
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
                _allowedToPress = true;
            }
        }
    }

    public void TaskHandling()
    {
        if (_allowedToPress)
        {
            //This is where we will add the reset and at the end change level.
            Debug.LogError("You pressed the button");
            if (_taskCounter == 5)
            {
                _paticipantManager.TeleportToNewRoom();
            }
            else
            {
                TheTaskOrder();
            }
            Reset();
            _taskCounter++;
            _timerIsRunning = true;
            _timeRemaining = 4;
            _allowedToPress = false;
        }
    }

    void Reset()
    {
        _theObjectManager.removeAll();
        _studentManager.ResetStudent();
        
        //Make Reset of position if level name is test2 and test3
        if (_sceneName == "Test2")
        {
            GameObject.Find("Students").GetComponent<ResetMinimap>().Reset();
        }

        if (_sceneName == "Test3")
        {
            GameObject pieces = GameObject.Find("Pieces");
            if (!pieces.activeSelf)
            {
                pieces.GetComponent<ResetMiniature>().TheReset();
                GameObject[] postITs = GameObject.FindGameObjectsWithTag("postIT");

                foreach (var postit in postITs)
                {
                    postit.GetComponent<MiniturePostItReset>().ResetMiniturePostIt();
                } 
            }
        }
        
    }

    private void TheTaskOrder()
    {
        //This needs to do the Text changing too later on.
        //Do the Text Order chancing in a help method.
        switch (_theParticipantNumber)
        {
            case 1:
            case 5:
                //set text order
                //Share to one, Share to 4, Share to all, Group share
                switch (_taskCounter)
                {
                    case 1:
                        SetText(_textArray[0]);
                        break;
                    case 2: 
                        SetText(_textArray[1]);
                        break;
                    case 3:
                        SetText(_textArray[2]);
                        break;
                    case 4:
                        SetText(_textArray[3]);
                        //Call Show Paper method
                        break;
                }
                break;
            case 2:
            case 6: 
                //set text order
                //Share to 4, Group share, Share to one, Share to all
                switch (_taskCounter)
                {
                    case 1:
                        SetText(_textArray[1]);
                        break;
                    case 2: 
                        SetText(_textArray[3]);
                        //Call Show Paper method
                        break;
                    case 3:
                        SetText(_textArray[0]);
                        break;
                    case 4:
                        SetText(_textArray[2]);
                        break;
                }
                break;
            case 3:
                //set text order
                //Group share, Share to all, Share to 4, Share to one
                switch (_taskCounter)
                {
                    case 1:
                        SetText(_textArray[3]);
                        //Call Show Paper method
                        break;
                    case 2: 
                        SetText(_textArray[2]);
                        break;
                    case 3:
                        SetText(_textArray[1]);
                        break;
                    case 4:
                        SetText(_textArray[0]);
                        break;
                }
                break;
            case 4:
                //set text order
                //Share to all, Share to one, Group share, Share to 4
                switch (_taskCounter)
                {
                    case 1:
                        SetText(_textArray[2]);
                        break;
                    case 2: 
                        SetText(_textArray[0]);
                        break;
                    case 3:
                        SetText(_textArray[3]);
                        //Call Show Paper method
                        break;
                    case 4:
                        SetText(_textArray[2]);
                        break;
                }
                break;
            default:
                //set text order
                break;

        }
        CheckGroupDocuments();
    }

    private void SetText(string textToSetItTo)
    {
        _textToEdit = GameObject.Find("TextToEdit").GetComponent<TMP_Text>();
        _textToEdit.text = textToSetItTo;
    }

    private void CheckGroupDocuments()
    {
        switch (_theParticipantNumber)
        {
            case 4 when _taskCounter == 3:
            case 1 when _taskCounter == 4:
            case 5 when _taskCounter == 4:
            case 2 when _taskCounter == 2:
            case 6 when _taskCounter == 2:
            case 3 when _taskCounter == 1:
                ActiveGroupDocuments();
                break;
            default:
                groupItems.SetActive(false);
                break;
        }
    }

    private void ActiveGroupDocuments()
    {
        groupItems.SetActive(true);
    }

    private void SetTextBasedONSceneName()
    {
        if (_sceneName == "Test1")
        {
            //RayCast method
            _textArray = new[] { "In this scenario you need to share the post-it with ONE person. \n" +
                                 "Do the following: \n Use the raypointing technique to select ONE person. \n Afterwards, share the post-it to your right with the selected people.",
                
                "In this scenario you need to share the post-it with SIX people. \n" +
                "Do the following: \n Use the raypointing technique to select SIX people. \n TWO people on EACH row. Afterwards, share the post-it to your right with the selected people.",
                
                "In this scenario you need to share the post-it with ALL people. \n" +
                "Do the following: \n Use the raypointing technique to select ALL people. \n Afterwards, share the post-it to your right with the selected people.",
                
                "For this scenario you need to share different post-its with different people.\n " +
                "Do the following: \n Use the raypointing technique to select FOUR people. Afterwards, share the RED post-it to your right with the selected people. \n" +
                "Next, select SIX people. Afterwards, share the BLUE post-it to your right with the selected people. \n" +
                "Lastly, select TWO people. Afterwards, share the YELLOW post-it to your right with the selected people."
            };


        } else if (_sceneName == "Test2")
        {
            //Minimap
            _textArray = new[] { "In this scenario you need to share the post-it with ONE person. \n" + 
                                 " Do the following: \n Use the minimap technique to select ONE person. \n Afterwards, share the post-it to your right with the selected people.",
                
                "In this scenario you need to share the post-it with SIX people. \n" +

                "Do the following: \n Use the minimap to select SIX people. TWO people on EACH row. \n Afterwards, share the post-it to your right with the selected people.",
                
                "In this scenario you need to share the post-it with ALL people. \n" +
                "Do the following: \n Use the minimap technique to select ALL people. \n Afterwards, share the post-it to your right with the selected people.",
                
                "For this scenario you need to share different post-its with different people. \n" +
                "Do the following: \n Use the minimap technique to select FOUR people. \n Afterwards, share the RED post-it to your right with the selected people. \n" +
                "Next, select SIX people. Afterwards, share the BLUE post-it to your right with the selected people.\n " +
                "Lastly, select TWO people. Afterwards, share the YELLOW post-it to your right with the selected people."
            };
        } else if (_sceneName == "Test3")
        {
            //Miniature
            _textArray = new[] { "In the first scenario you need to share the post-it with ONE person. \n " +
                                 "Do the following: \n Use the miniature technique to select ONE person. \n Afterwards, share the post-it to your right with the selected people.",
                
                "In this scenario you need to share the post-it with SIX people. \n" +
                "Do the following: Use the miniature technique to select SIX people. \n TWO people on EACH row. Afterwards, share the post-it to your right with the selected people.",
                
                "In this scenario you need to share the post-it with ALL people. \n" +
                "Do the following: \n Use the miniature technique to select ALL people. \n Afterwards, share the post-it to your right with the selected people.",
                
                "For this scenario you need to share different post-its with different people. \n" +
                "Do the following: \n Use the miniature technique to select FOUR people. \n Afterwards, share the RED post-it to your right with the selected people. \n" +
                "Next, select SIX people. Afterwards, share the BLUE post-it to your right with the selected people. \n" +
                "Lastly, select TWO people. Afterwards, share the YELLOW post-it to your right with the selected people."
            };
        }
        else
        {
            // NOTHING!
        }
    }
    
}
