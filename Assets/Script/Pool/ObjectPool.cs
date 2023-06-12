using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject objectToPool;

    public Queue<GameObject> thePool = new Queue<GameObject>();

    public int startAmount;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        GameObject obj;
        for (int i = 0; i < startAmount; i++)
        {
            obj = Instantiate(objectToPool);
            thePool.Enqueue(obj);
            obj.SetActive(false);
            obj.transform.parent = transform;
        }
    }
    public GameObject SpawnObject(Vector3  position,Quaternion rotation)
    {
        GameObject toReturn;
        if (thePool.Count > 0)
        {
            toReturn = thePool.Dequeue();
            toReturn.SetActive(true);
        }
        else
        {
            toReturn = Instantiate(objectToPool);
            toReturn.transform.parent = transform;
        }

        toReturn.transform.position = position;
        toReturn.transform.rotation = rotation;
        return toReturn;
    }

    public void ReturnObject(GameObject objectToReturn)
    {
        if (thePool.Count <= 10)
        {
            if (!thePool.Contains(objectToReturn))
            {
                thePool.Enqueue(objectToReturn);
                objectToReturn.SetActive(false);
            }
        }
        else
        { 
          Destroy(objectToReturn);
        }
    }
}
