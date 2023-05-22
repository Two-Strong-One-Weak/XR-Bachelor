using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    public List<GameObject> _studentList;
    public List<GameObject> _listOfAllStudents;
    private GameObject theStudent = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var st in GameObject.FindGameObjectsWithTag("Students"))
        {
            _listOfAllStudents.Add(st);
        }
    }

    public GameObject GetStudent(String student)
    {
        foreach (var st in _listOfAllStudents)
        {
            if (st.name == student)
            {
                theStudent = st;
                return theStudent;
            }
        }
        return null;

    }

    public void AddStudent(GameObject student)
    {
        if (!_studentList.Contains(student))
        {
            _studentList.Add(student);
        }
    }

    public void RemoveStudent(GameObject student)
    {
        if (_studentList.Contains(student))
        {
            _studentList.Remove(student);
        }
    }

    public void ResetStudent()
    {
        foreach (var st in _studentList)
        {
           GameObject childObj = st.transform.GetChild(0).gameObject;
           childObj.SetActive(false);
           childObj.GetComponent<PlayerSelectionScript>()._selected = false;
           childObj.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        }
        _studentList.Clear();
    }
    
}
