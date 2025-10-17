using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public GameObject objectToPool;
    public int amountToPool = 20;

    // ?? Actual storage for pooled objects
    private List<GameObject> pooledObjects = new List<GameObject>();

    // ?? Public read-only access (so other scripts like RhythmSpawner can iterate)
    public List<GameObject> PooledObjects
    {
        get { return pooledObjects; }
    }

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }
        return null;
    }

    public void ClearAll()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.activeSelf)
                obj.SetActive(false);
        }
    }
}
