using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
        if (ItemItemInteraction.currentItemName != null)
        {
            Debug.Log("Reset currentItemCarried as null...!");
            ItemItemInteraction.currentItemName = null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
