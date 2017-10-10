using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFall : MonoBehaviour {

    public float fallSpeed = 1.5f;

    private Rigidbody2D itemRigibody;

    private void Start()
    {
        itemRigibody = GetComponent<Rigidbody2D>();
    }
    
    void Update () {
        
        if (gameObject.tag == "Falling" || gameObject.tag == "BadTouch" || gameObject.tag == "GoodTouch")
        {
            itemRigibody.velocity = fallSpeed * (itemRigibody.velocity.normalized);
            
        }
        else
        {
            itemRigibody.velocity = new Vector2(0, 0);
        }
        
	}
}
