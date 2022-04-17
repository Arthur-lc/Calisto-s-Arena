using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectToPool;
    public int poolSize = 10;
    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        GameObject tmp;
        for (int i = 0; i < poolSize; i++)
        {
            tmp = Instantiate(objectToPool, this.transform);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return IncreasePool();
    }

    public GameObject IncreasePool() {
        Debug.Log("Pool Increased");
        poolSize++;
        GameObject tmp;
        tmp = Instantiate(objectToPool, this.transform);
        tmp.SetActive(false);
        pool.Add(tmp);
        return tmp;
    }
}
