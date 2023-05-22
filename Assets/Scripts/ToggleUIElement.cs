using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleUIElement : MonoBehaviour
{
    private bool _selected;
    private Toggle _thisToggle;
    private Image _thisImage;
    private StudentManager _theStudentManager;
    private ObjectManager _objectManager;

   

    private void Awake()
    {
        _thisToggle = gameObject.GetComponent<Toggle>();
        _thisImage = gameObject.GetComponent<Image>();
        _theStudentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();
        _objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        
        _selected = false;
    }

    private void Start()
    {
        
        if (_thisImage == null)
        {
            Debug.LogError("YOU DID NOT FIND THE IMAGE!!!");
        }
        _thisToggle.onValueChanged.AddListener(delegate
        {
            OnSelect();
        });
    }
    public void OnSelect()
    {
        if (!_selected)
        {
            _thisImage.color = Color.green;
            _selected = true;
            _theStudentManager.AddStudent(_theStudentManager.GetStudent(gameObject.transform.Find("Name").GetComponentInChildren<TMP_Text>().text));
            
        }
        else
        {
            _thisImage.color = Color.white;
            _selected = false;
           // _objectManager.removeObject(_theStudentManager.GetStudent(gameObject.transform.Find("Name").GetComponentInChildren<TMP_Text>().text).name);
            _theStudentManager.RemoveStudent(_theStudentManager.GetStudent(gameObject.transform.Find("Name").GetComponentInChildren<TMP_Text>().text));
        }
    }
}
