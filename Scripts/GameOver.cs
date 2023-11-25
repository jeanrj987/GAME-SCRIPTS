using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControl.instance.deathTrigger();
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            Destroy(collision.gameObject, 1f);

            GameController.instance.GameOverTrigger();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
