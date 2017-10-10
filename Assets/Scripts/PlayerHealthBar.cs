using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour {

    public Image healthBar;
    public Text  playerScore;
    public float playerHP = 100;

    private float fullHp;
    public int score = 0;
    
	void Start () { 
        fullHp = playerHP;
	}
	
	void Update () {
        playerScore.text = score.ToString();
        if (playerHP > fullHp)
        {
            playerHP = fullHp;
        }
        if (playerHP <= 0)
        {
            // you have died
            LoadDeathScene();
        }
        healthBar.rectTransform.localScale = new Vector3(playerHP / fullHp, 1, 1);
	}

    void LoadDeathScene()
    {
        SceneManager.LoadScene("Death");
    }
}
