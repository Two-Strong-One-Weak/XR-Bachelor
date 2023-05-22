using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public List<GameObject> listOfObjects;
    // Start is called before the first frame update
    void Start()
    {
        listOfObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addObject(GameObject theObject)
    {
        listOfObjects.Add(theObject);
    }

    public void removeAll()
    {
        Debug.LogError(listOfObjects);
        foreach (GameObject clone in listOfObjects)
        {
            Destroy(clone);
        }
        listOfObjects.Clear();
    }

    public void removeObject(string theObjectName)
    {
        foreach (var clone in listOfObjects)
        {
            if (clone.name == theObjectName)
            {
                listOfObjects.Remove(clone);
            }
        }
        
    }
    
}
