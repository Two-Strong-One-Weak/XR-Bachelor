using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadTest1()
    {
        SceneManager.LoadScene("Test1");
        
    }
    
    public void LoadTest2()
    {
        SceneManager.LoadScene("Test2");

    }
    
    public void LoadTest3()
    {
        SceneManager.LoadScene("Test3");

    }
    
    public void LoadTest4()
    {
        SceneManager.LoadScene("Test4");

    }
    
    public void LoadTest5()
    {
        SceneManager.LoadScene("Test5");

    }
    
    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndOfTestScene");

    }
}
