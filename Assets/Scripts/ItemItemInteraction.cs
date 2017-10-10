using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemItemInteraction : MonoBehaviour {

    public GameObject errorPopup;

    private Rigidbody2D thisRigibody;
    // keep this in player's health script...................... sorry abt bad naming conventions.....
    public static string currentItemName;
    private static string[] goodItemNames = { "BustTorso", "BustChest", "BustNeck", "BustHead" };

    private GameObject player;
    PlayerHealthBar playerHealthBarScript;
    
    private void Start()
    {
        thisRigibody = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Podium");
        playerHealthBarScript = player.GetComponent<PlayerHealthBar>();
    }

    /* rightItem checks if you have collected the right item by checking if item touched is the same as current's correct next piece
     * When item is added to podium, we save its object name in currentItemName.
     * */
    private bool RightItemCollected(GameObject potentialNext)
    {
        int indx;
        if (currentItemName == null)
        {
            // if you HAVE NOT collected an item yet
            // IN THIS CASE, index gets index of POTENTIAL_NEXT and checks if it is the first item to get....
            indx = System.Array.IndexOf(goodItemNames, potentialNext.name);
            if (indx == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // if you HAVE collected items
            // IN THIS CASE, index gets index of CURRENT_ITEM and checks if potential's name is its next
            indx = System.Array.IndexOf(goodItemNames, currentItemName);
            if ((indx += 1) > 3)
            {
                Debug.Log("You have won this level");
                return true;
            }
            else
            {
                if (goodItemNames[indx++] == potentialNext.name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    void displayErrorPopup()
    {
        Vector3 randPos = new Vector3(Random.Range(-7f, 8f), Random.Range(-4f, 5f), -7);
        Instantiate(errorPopup, randPos, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collidedWith)
    {
        if (this.gameObject.tag == "BadTouch" && collidedWith.gameObject.tag == "TopSticky")
        {
            Debug.Log(gameObject.name);
            playerHealthBarScript.playerHP -= 10.0f;
            gameObject.SetActive(false);
        }
        else if (this.gameObject.tag == "GoodTouch" && collidedWith.gameObject.tag == "TopSticky")
        {
            // If you have collided with good item
            playerHealthBarScript.playerHP += 5.0f;
            gameObject.SetActive(false);
        }
        else if (this.gameObject.tag == "Falling" && collidedWith.gameObject.tag == "TopSticky")
        {
            // If you have touched a fallen item
            if (RightItemCollected(this.gameObject))
            {
                // Collected item in right order
                GameWin.objectsOnPodium.Add(this.gameObject);
                
                // Increment score
                playerHealthBarScript.score += 5;

                // Changing each other's properties
                currentItemName = this.gameObject.name;         // change current item string to item you interacted with (this to for RightItemCollected method...)
                this.gameObject.tag = "TopSticky";              // fallen item now should be able to collect future items
                collidedWith.gameObject.tag = "Sticky";         // item below top sticky SHOULD NOT collect other items...

                /* WORK ON THIS LATER */
                /*
                float yCoord = this.transform.position.y;
                if (yCoord < collidedWith.transform.position.y) { yCoord = collidedWith.transform.position.y - this.transform.position.y; }
                this.transform.position = new Vector3(collidedWith.transform.position.x, yCoord, this.transform.position.z);
                */
                this.transform.position = new Vector3(collidedWith.transform.position.x, this.transform.position.y, this.transform.position.z); // snap to new location
                this.transform.parent = collidedWith.transform;
                thisRigibody.bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                // Collected wrong item!
                playerHealthBarScript.playerHP -= 5.0f;
                displayErrorPopup();
                gameObject.SetActive(false);
            }
        }
        else if (collidedWith.gameObject.name == "Floor")
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
