using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateNameAboveHead : MonoBehaviour
{

    private string _name;

    private TMP_Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("NameCanvas");
        nameText = new GameObject().AddComponent<TMP_Text>();
        nameText.transform.SetParent(canvas.transform);
        nameText.SetText(_name);
        nameText.rectTransform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        nameText.transform.position = screenPos;
        nameText.transform.rotation =
            Quaternion.LookRotation(nameText.transform.position - Camera.main.transform.position);
    }
}
