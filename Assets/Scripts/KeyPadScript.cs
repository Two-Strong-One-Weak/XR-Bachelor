using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadScript : MonoBehaviour
{
    
    private int _numberPicked;
    public Text _numberText;

    private PaticipantManager _paticipantManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _paticipantManager = GameObject.Find("PaticipantManager").GetComponent<PaticipantManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setNumber()
    {
        //Debug.LogError(_numberText);
        //Debug.LogError(_numberText.text);
        //_numberPicked = Int32.Parse(_numberText.text);
        //Add so it takes the PaticipantManager and send the number to it.
        _paticipantManager.setNumber(Int32.Parse(_numberText.text));

    }
}
