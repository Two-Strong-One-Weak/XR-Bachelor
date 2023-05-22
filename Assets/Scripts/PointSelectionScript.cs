using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSelectionScript : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private void Awake()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        UpdatePointer();
    }

    void UpdatePointer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            GameObject targetObject = hit.collider.gameObject;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, targetObject.transform.position);
        }
        else
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, transform.position+transform.forward * 10);
        }
    }
}
