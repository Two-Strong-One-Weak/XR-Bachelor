using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomPostItScript : MonoBehaviour
{

    public bool grabbed = false;
    
    public void IsGrabbed()
    {
        grabbed = true;
    }

    public void NotGrabbed()
    {
        grabbed = false;
    }
}
