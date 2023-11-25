using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    public int Score;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            GameController.instance.coinScore += Score;
            GameController.instance.CoinScoreUpdate();

            Destroy(gameObject);
        }
    }
}
