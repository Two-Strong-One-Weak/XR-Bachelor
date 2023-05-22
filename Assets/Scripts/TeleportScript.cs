using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    //This code should be generalized instead but for now its fine!
    public GameObject postItToDisable1;
    public GameObject postItToDisable2;
    private Vector3 _teleportRoom = new(0, 0, 0);
    private Vector3 teleportLocation1 = new(2, 0.7f, -109.4f);
    private Vector3 teleportLocation2 = new(0, 0, -201);
    private Vector3 teleportLocation3 = new(0, 0, -301);
    private Vector3 teleportLocation4 = new(0, 0, -401);
    private Vector3 devRoomLocation = new(-1000, 0, 0);
    private Transform Player;
    private float _fadeDuration = 1.5f;

    public void Awake()
    {

    }

    public void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        Debug.Log(Player);
    }


    public void Teleport1()
    {
        postItToDisable1.SetActive(true);
        postItToDisable2.SetActive(false);
        StartCoroutine(TeleportCoroutine(teleportLocation1));
    }
    
    public void Teleport2()
    {
        postItToDisable1.SetActive(false);
        postItToDisable2.SetActive(true);
        StartCoroutine(TeleportCoroutine(teleportLocation2));
    }
    
    public void Teleport3()
    {
        StartCoroutine(TeleportCoroutine(teleportLocation3));
    }
    
    public void Teleport4()
    {
        StartCoroutine(TeleportCoroutine(teleportLocation4));
    }

    public void DevRoomTeleport()
    {
        StartCoroutine(TeleportCoroutine(devRoomLocation));
    }

    public void TeleportBack()
    {
        StartCoroutine(TeleportCoroutine(_teleportRoom));
    }

    private IEnumerator TeleportCoroutine(Vector3 teleportLocation)
    {
        float timer = 0.0f;
        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Player.position = teleportLocation;

        timer = 0.0f;
        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

    }
    
}
