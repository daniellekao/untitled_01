using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour {

    public static List<GameObject> objectsOnPodium;

    private GameObject player;

    private void Start()
    {
        objectsOnPodium = new List<GameObject>();
        player = GameObject.Find("Podium");
    }
    
    void Update () {
        if (objectsOnPodium.Count == 4)
        {
            Invoke("ReleaseCollectedItems", 0.5f);
            player.tag = "TopSticky";
            
        }
    }

    void ReleaseCollectedItems()
    {
        for (int i = 0; i < objectsOnPodium.Count; ++i)
        {
            GameObject obj = objectsOnPodium[i];
            Rigidbody2D objRigidbody2D = obj.GetComponent<Rigidbody2D>();

            //set as inactive, send back to object pool
            obj.SetActive(false);

            //change back to falling item (change tag, transform parent, velocity)
            obj.tag = "Falling";
            obj.transform.parent = null;
            objRigidbody2D.bodyType = RigidbodyType2D.Dynamic;

            // set current item back to null...!
            ItemItemInteraction.currentItemName = null;
        }
        objectsOnPodium = new List<GameObject>();

    }
}
