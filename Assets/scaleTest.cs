using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleTest : MonoBehaviour
{
    public GameObject cube;
    public float scaleFactorX = 0.1f;
    public OVRHand leftHand;
    public OVRHand rightHand;

    private bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void scale()
    {
        Debug.Log("Scale");
        // Check if the object is being grabbed by both hands
        if (!isGrabbed && (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index)))
        {
            isGrabbed = true;
        }
        else if (isGrabbed && (!leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index) || !rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index)))
        {
            isGrabbed = false;
        }

        // If the object is being grabbed by both hands, scale it along the X-axis
        if (isGrabbed)
        {
            // Get the positions of both hands
            Vector3 leftHandPosition = leftHand.transform.position;
            Vector3 rightHandPosition = rightHand.transform.position;

            // Caluculate the distance between the hands along the x-axis
            float distanceX = Mathf.Abs(leftHandPosition.x - rightHandPosition.x);

            // Modify the X component of the localScale vector using the distance and scale factor 
            Vector3 localScale = cube.transform.localScale;
            localScale.x = distanceX * scaleFactorX;

            // Set the object's localScale property to the modified localScale vector 
            cube.transform.localScale = localScale;
        }
    }

    public void noScale()
    {

    }
}
