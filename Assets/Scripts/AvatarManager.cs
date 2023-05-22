using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public GameObject metaAvatar;


    private void Awake()
    {
        DontDestroyOnLoad(metaAvatar);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }
}
