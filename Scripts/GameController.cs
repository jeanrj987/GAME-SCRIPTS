using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int coinScore;
    public TextMeshProUGUI textScore;

    public GameObject gameOver;
    public GameObject nextLevel;

    public static bool setActiveStartSpawn = false;
    public static Vector3 resPos;

    // Start is called before the first frame update 
    void Start()
    {
        instance = this;

        NextLevel.totalCoins = GameObject.FindGameObjectsWithTag("CoinCount").Length;
    }
   
    public void CoinScoreUpdate()
    {
       textScore.text = (coinScore < 10) ? "0" + coinScore.ToString() : coinScore.ToString();
    }
    public void GameOverTrigger()
    {
        Invoke(nameof(GameOver), 0.5f);
    }
    public void GameOver()
    {
        gameOver.SetActive(true);  
    }
    public void NextLevelTrigger()
    {
        nextLevel.SetActive(true);
    }
    public void LevelToBeLoaded(string lvName)
    {
        SceneManager.LoadScene(lvName);
    }
}
