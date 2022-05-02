using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    
    public int lives = 20;
    public int money = 100;
    //TODO: Set moneyValue increasing by the time pass!
    //public static int moneyValue = 5; // enemies worth 
    public Text moneyText;
    public Text livesText;

    public void LoseLife(int l = 1)
    {
        lives -= l;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    
    void GameOver()
    {
        Debug.Log("Game Over!");
        //TODO: Send the player to a game over screen!
        //TODO: Stop the game!
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // get the active sceen so that you can start back over!
    }

    void Update()
    {
        //FIXME: This doesn't actually need to update the text every frame!
        moneyText.text = "Money: " + money.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
