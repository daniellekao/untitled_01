using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorPopupScript : MonoBehaviour {
    
    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
