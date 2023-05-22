using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPostIts : MonoBehaviour
{

    private ObjectManager _objectManager;

    private StudentManager _studentManager;
    private string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        _objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        _studentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();
    }
    
    public void RemoveAllPostIts()
    {
        _objectManager.removeAll();
        _studentManager.ResetStudent();
        
        if (_sceneName == "Test2")
        {
            GameObject.Find("Students").GetComponent<ResetMinimap>().Reset();
        }
        
        if (_sceneName == "Test3")
        {
            GameObject.Find("Pieces").GetComponent<ResetMiniature>().TheReset();
            GameObject[] postITs = GameObject.FindGameObjectsWithTag("postIT");
            foreach (var postit in postITs)
            {
                postit.GetComponent<MiniturePostItReset>().ResetMiniturePostIt();
            }
        }
    }
}
