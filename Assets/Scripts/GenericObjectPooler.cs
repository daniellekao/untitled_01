using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPooler : MonoBehaviour {

    public GenericObjectPooler current; //was static.....?
    public GameObject objectToPool;
    public int pooledAmount = 10;
    public bool willGrow = true;

    private List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
    }

    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);

            // remove "(Clone)" from name...
            obj.name = obj.name.Substring(0, obj.name.IndexOf("("));

            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}
	
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!(pooledObjects[i].activeInHierarchy))
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            Debug.Log("making new object in object pool");
            GameObject obj = (GameObject)Instantiate(objectToPool);
            pooledObjects.Add(obj);
            return obj;

        }
        return null;
    }
}