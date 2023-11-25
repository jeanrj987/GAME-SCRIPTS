using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnBow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControl.instance.bowEnabled = true;
            Destroy(gameObject);
        }
    }
}
