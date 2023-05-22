using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleOutline()
    {
        if (gameObject.GetComponent<Outline>().enabled)
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }
    }
}
