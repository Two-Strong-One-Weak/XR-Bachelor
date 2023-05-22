using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMinimap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<HandClassRoomSendScript>().ResetPerson();
        }
    }
}