using System.Collections;
using System.Collections.Generic;
using Oculus.Avatar2;
using UnityEngine;

public class RequestTokenAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OvrAvatarEntitlement.ResendAccessToken();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
