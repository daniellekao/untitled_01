using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public float spawnRate = 1f;        // lower the rate, the faster the spawn time...
    public int pooledAmount = 10;

    public GameObject head;

    private List<GameObject> objects;

	// Use this for initialization
	void Start () {
        objects = new List<GameObject>();
        // add 10 objects into pool and set as inactive
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(head);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
