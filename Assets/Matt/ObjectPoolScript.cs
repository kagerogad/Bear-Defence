using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour
{
    public static ObjectPoolScript instance;
    [SerializeField]
    private GameObject poolObject;
    [SerializeField]
    private int poolSize = 30;

    private List<GameObject> objectPool;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newPoolObject = (GameObject)Instantiate(poolObject);
            newPoolObject.SetActive(false);
            objectPool.Add(newPoolObject);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }

        return null;
    }

}
