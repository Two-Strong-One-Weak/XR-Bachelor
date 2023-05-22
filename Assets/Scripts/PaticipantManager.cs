using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaticipantManager : MonoBehaviour
{

    public static int number;
    private int teleportCounter;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        teleportCounter = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNumber(int theNumber)
    {
        number = theNumber;
        Debug.LogError("The Number recieved was: " + number);
    }

    public void printNumber()
    {
        Debug.LogError("The Number is: " + number);
    }

    public int getNumber()
    {
        return number;
    }

    public void TeleportToNewRoom()
    {
        WhereToTeleportToo();
        teleportCounter++;
    }

    private void WhereToTeleportToo()
    {
        switch (number)
        {
            case 1:
                if (teleportCounter == 0)
                {
                    SceneManager.LoadScene("Test1");
                }else if (teleportCounter == 1)
                {
                    SceneManager.LoadScene("Test2");
                } else if (teleportCounter == 2)
                {
                    SceneManager.LoadScene("Test3");
                }
                else if(teleportCounter == 3)
                {
                    SceneManager.LoadScene("EndOfTestScene");
                }
                break;
            case 2:
                if (teleportCounter == 0)
                {
                    SceneManager.LoadScene("Test1");
                }else if (teleportCounter == 1)
                {
                    SceneManager.LoadScene("Test3");
                } else if (teleportCounter == 2)
                {
                    SceneManager.LoadScene("Test2");
                }
                else if(teleportCounter == 3)
                {
                    SceneManager.LoadScene("EndOfTestScene");
                }
                break;
            case 3:
                if (teleportCounter == 0)
                {
                    SceneManager.LoadScene("Test3");
                }else if (teleportCounter == 1)
                {
                    SceneManager.LoadScene("Test1");
                } else if (teleportCounter == 2)
                {
                    SceneManager.LoadScene("Test2");
                }
                else if(teleportCounter == 3)
                {
                    SceneManager.LoadScene("EndOfTestScene");
                }
                break;
            case 4:
                if (teleportCounter == 0)
                {
                    SceneManager.LoadScene("Test3");
                }else if (teleportCounter == 1)
                {
                    SceneManager.LoadScene("Test2");
                } else if (teleportCounter == 2)
                {
                    SceneManager.LoadScene("Test1");
                }
                else if(teleportCounter == 3)
                {
                    SceneManager.LoadScene("EndOfTestScene");
                }
                break;
            case 5:
                if (teleportCounter == 0)
                {
                    SceneManager.LoadScene("Test2");
                }else if (teleportCounter == 1)
                {
                    SceneManager.LoadScene("Test3");
                } else if (teleportCounter == 2)
                {
                    SceneManager.LoadScene("Test1");
                }
                else if(teleportCounter == 3)
                {
                    SceneManager.LoadScene("EndOfTestScene");
                }
                break;
            case 6:
                if (teleportCounter == 0)
                {
                    SceneManager.LoadScene("Test2");
                }else if (teleportCounter == 1)
                {
                    SceneManager.LoadScene("Test1");
                } else if (teleportCounter == 2)
                {
                    SceneManager.LoadScene("Test3");
                }
                else if(teleportCounter == 3)
                {
                    SceneManager.LoadScene("EndOfTestScene");
                }
                break;
            default:
                Debug.LogError("The Number was not in the switch");
                break;
        }
    }

    
    
    
}
