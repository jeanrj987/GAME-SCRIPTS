using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public float percentOfApples;
    public static int totalCoins;

    public GameObject oneStar;
    public GameObject twoStars;
    public GameObject threStars;

    void Update()
    {
        percentOfApples = (float)GameController.instance.coinScore / totalCoins;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && percentOfApples >= 0.7)
        {
            GameController.instance.NextLevelTrigger();
            Destroy(collider.gameObject);

            GameController.setActiveStartSpawn = false;

            if (percentOfApples >= 1)
            {
                threStars.SetActive(true);
            }
            else if (percentOfApples < 1)
            {
                twoStars.SetActive(true);
            }
        }
    }
}
