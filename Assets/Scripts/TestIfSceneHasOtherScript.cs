using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIfSceneHasOtherScript : MonoBehaviour
{

    private PaticipantManager _paticipantManager;

    private void Awake()
    {
        _paticipantManager = GameObject.Find("PaticipantManager").GetComponent<PaticipantManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _paticipantManager.printNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
