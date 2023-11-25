using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public static Check instance;
    public bool checkpointEnabled;

    private void Start()
    {
        instance = this;

        isCheckpointEnabled();
    }


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkpointEnabled)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameController.setActiveStartSpawn = true;
                GameController.resPos = transform.position;

                checkpointEnabled = false;
            }
        }
    }
    public void isCheckpointEnabled()
    {
        if (GameController.resPos.x == 0 && GameController.resPos.y == 0 || (GameController.resPos.x != transform.position.x && GameController.resPos.y != transform.position.y && GameController.resPos.x < transform.position.x))
        {
            checkpointEnabled = true;
        }
        else
        {
            checkpointEnabled = false;
        }
    }
}
