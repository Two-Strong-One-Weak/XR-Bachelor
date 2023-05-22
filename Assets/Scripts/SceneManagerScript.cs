using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private AsyncOperation _sceneAsync;
    private int _sceneNumber;

    /*private void Start()
    {
        
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        _sceneAsync = scene;
        
        //Wait until we are done loadin the scene
        while (scene.progress < 0.9f)
        {
            Debug.LogError("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        OnFinishedLoadingALlScene();
    }

    void EnableScene(int index)
    {
        //Activate the Scene
        _sceneAsync.allowSceneActivation = true;

        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.LogError("Scene is Valid");
            SceneManager.MoveGameObjectToScene(gameObject, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
        }
    }

    void OnFinishedLoadingALlScene()
    {
        Debug.LogError("Done Loading Scene");
        EnableScene(1);
        Debug.LogError("Scene Activated!");
    } */

    public void SetSceneToLoad(int sceneNumber)
    {
        _sceneNumber = sceneNumber;
    }

    public void LoadTheScene()
    {
        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(_sceneNumber);
        
        SceneManager.MoveGameObjectToScene(gameObject, sceneToLoad);
        SceneManager.LoadScene(SceneNameBasedOnNumber());
    }

    String SceneNameBasedOnNumber()
    {
        switch (_sceneNumber)
        {
            case 1:
                return "Test1";
            case 2:
                return "Test2";
            case 3:
                return "Test3";
            default:
                return "EndOfTestScene";
        }
    }
    
}
