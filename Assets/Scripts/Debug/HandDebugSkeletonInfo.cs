using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum HandInfoFrequency
{
    none,
    Once,
    Repeat
}


public class HandDebugSkeletonInfo : MonoBehaviour
{
    [SerializeField] private OVRHand hand;

    [SerializeField] private OVRSkeleton handSkeleton;

    [SerializeField] private HandInfoFrequency _handInfoFrequency = HandInfoFrequency.Once;

    private bool handInfoDisplayed = false;

    private bool pauseDisplay = false;

    private void Awake()
    {
        if (!hand) hand = GetComponent<OVRHand>();
        if (!handSkeleton) handSkeleton = GetComponent<OVRSkeleton>();
        
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) pauseDisplay = !pauseDisplay;
#endif

        if (hand.IsTracked && !pauseDisplay)
        {
            if (_handInfoFrequency == HandInfoFrequency.Once && !handInfoDisplayed)
            {
                DisplayBoneInfo();
                handInfoDisplayed = true;
            } else if (_handInfoFrequency == HandInfoFrequency.Repeat) {
                DisplayBoneInfo();
            }
        }

    }

    private void DisplayBoneInfo()
    {
        foreach (var bone in handSkeleton.Bones)
        {
          Logger.Instance.LogInfo($"{handSkeleton.GetSkeletonType()}: boneID -> {bone.Id} pos -> {bone.Transform.position}");
        }
        
        Logger.Instance.LogInfo($"{handSkeleton.GetSkeletonType()}: num of bones -> {handSkeleton.GetCurrentNumBones()}");
        Logger.Instance.LogInfo($"{handSkeleton.GetSkeletonType()}: num of skinnable bones -> {handSkeleton.GetCurrentNumSkinnableBones()}");
        Logger.Instance.LogInfo($"{handSkeleton.GetSkeletonType()}: start one ID -> {handSkeleton.GetCurrentStartBoneId()}");
        Logger.Instance.LogInfo($"{handSkeleton.GetSkeletonType()}: end bone id -> {handSkeleton.GetCurrentEndBoneId()}");
        
    }
}
