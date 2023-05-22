using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandMenuSelectedCounter : MonoBehaviour
{

    private Text _text;

    private StudentManager _studentManager;
    // Start is called before the first frame update
    void Start()
    {
        _text = gameObject.GetComponent<Text>();
        _studentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _studentManager._studentList.Count + "/" + _studentManager._listOfAllStudents.Count + " selected";
    }
}
