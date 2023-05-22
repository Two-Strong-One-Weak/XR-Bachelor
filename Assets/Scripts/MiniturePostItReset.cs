using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniturePostItReset : MonoBehaviour
{
    private Vector3 _PostItPosition;

    private Quaternion _PostItRotation;
    // Start is called before the first frame update
    void Start()
    {
        _PostItPosition = gameObject.transform.position;
        _PostItRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMiniturePostIt()
    {
        gameObject.transform.position = _PostItPosition;
        gameObject.transform.rotation = _PostItRotation;
    }
}
