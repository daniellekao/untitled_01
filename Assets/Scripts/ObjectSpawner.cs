using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public float screenSize = 9;
    public float spawnRate  = 3;
    public GameObject headObjPool;
    public GameObject neckObjPool;
    public GameObject chestObjPool;
    public GameObject torsoObjPool;
    public GameObject badObjPool;
    public GameObject goodObjPool;

    private float   nextSpawn = 0f;
    private int     nextObjectIndx;
    private float   randX;
    private float   zCoord;
    private Vector3 spawnLocation;
    
	void Update () {
        // When game time passes nextSpawn time: When it is time to spawn new item
        if (Time.time > nextSpawn)
        {
            // set next spawn time
            nextSpawn = Time.time + spawnRate;

            /* randomly choose which item to display  
             * 0: head   1: neck     2: chest, 
             * 3: torso  4: bad obj  5: good obj  */
            nextObjectIndx = (int)Random.Range(0, 6);
            randX = (float)Random.Range((-1 * screenSize), screenSize);
            switch (nextObjectIndx)
            {
                case 0:
                    spawnLocation = new Vector3(randX, transform.position.y, -2f);
                    spawnFromObjPool(headObjPool, spawnLocation);
                    break;
                case 1:
                    spawnLocation = new Vector3(randX, transform.position.y, 0f);
                    spawnFromObjPool(neckObjPool, spawnLocation);
                    break;
                case 2:
                    spawnLocation = new Vector3(randX, transform.position.y, 1f);
                    spawnFromObjPool(chestObjPool, spawnLocation);
                    break;
                case 3:
                    spawnLocation = new Vector3(randX, transform.position.y, 1.5f);
                    spawnFromObjPool(torsoObjPool, spawnLocation);
                    break;
                case 4:
                    spawnLocation = new Vector3(randX, transform.position.y, 0f);
                    spawnFromObjPool(badObjPool, spawnLocation);
                    break;
                case 5:
                    spawnLocation = new Vector3(randX, transform.position.y, 0f);
                    spawnFromObjPool(goodObjPool, spawnLocation);
                    break;
            }
        }
	}

    void spawnFromObjPool(GameObject objPool, Vector3 pos)
    {
        GameObject obj = objPool.GetComponent<GenericObjectPooler>().current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }
}
