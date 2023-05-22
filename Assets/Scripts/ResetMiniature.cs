using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMiniature : MonoBehaviour
{
    private Transform[] _childTransforms;
    private Vector3[] _childPositions;
    private Quaternion[] _childRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        _childTransforms = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _childTransforms[i] = transform.GetChild(i);
        }
        
        StoreChildPosition();
    }

    private void StoreChildPosition()
    {
        _childPositions = new Vector3[_childTransforms.Length];
        _childRotation = new Quaternion[_childTransforms.Length];

        for (int i = 0; i < _childTransforms.Length; i++)
        {
            _childPositions[i] = _childTransforms[i].position;
            _childRotation[i] = _childTransforms[i].rotation;
        }
    }

    private void RestoreChildPositions()
    {
        for (int i = 0; i < _childTransforms.Length; i++)
        {
            _childTransforms[i].position = _childPositions[i];
            _childTransforms[i].rotation = _childRotation[i];
            _childTransforms[i].GetComponent<FigureSendOption>()._hasBeenSent = false;
        }
    }

    public void TheReset()
    {
        RestoreChildPositions();
    }
}
