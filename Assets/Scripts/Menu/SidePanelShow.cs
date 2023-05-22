using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePanelShow : MonoBehaviour
{
    
    private GameObject _theSidePanel;
    private StudentManager _theStudentManager;
    // Start is called before the first frame update
    void Start()
    {
        _theStudentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();

        _theSidePanel = GameObject.Find("SidePanel");

        if (_theSidePanel == null)
        {
            Debug.LogError("Can't Find the sidePanel!");
        }

        _theSidePanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_theStudentManager._studentList.Count > 0)
        {
            _theSidePanel.SetActive(true);
        }
        else
        {
            _theSidePanel.SetActive(false);
        }
    }
}
