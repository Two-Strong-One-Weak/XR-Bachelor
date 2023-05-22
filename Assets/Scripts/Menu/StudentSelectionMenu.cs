using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class StudentSelectionMenu : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject sendButton;
    private StudentManager _theStudentManager;
    private float _itemOffSet;

    private void Start()
    {
        _theStudentManager = GameObject.Find("GameManager").GetComponent<StudentManager>();
        
        //Maybe send to all before.
        
        foreach (var students in _theStudentManager._listOfAllStudents)
        {
            GameObject studentCard = Instantiate(itemPrefab);
            Vector3 originalSize = studentCard.transform.localScale;
            studentCard.transform.SetParent(gameObject.transform, false);
            studentCard.transform.localScale = originalSize;
            studentCard.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, _itemOffSet);
            GameObject nameTextObject = studentCard.transform.Find("Name").gameObject;
            TMP_Text textMeshPro = nameTextObject.GetComponent<TMP_Text>();
            textMeshPro.SetText(students.name);
           /* Toggle toggleOn = studentCard.GetComponent<Toggle>();
            toggleOn.group = gameObject.GetComponent<ToggleGroup>();*/
            
            _itemOffSet += -90.0f;
        }
        
        //add send button
        GameObject sendButtonCard = Instantiate(sendButton);
        Vector3 theSize = sendButtonCard.transform.localScale;
        sendButtonCard.transform.SetParent(gameObject.transform, false);
        sendButtonCard.transform.localScale = theSize;
        sendButtonCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, _itemOffSet);
    }
}
