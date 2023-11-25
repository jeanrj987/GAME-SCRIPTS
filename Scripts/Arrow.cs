using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrow;
    public float speed;

    public static bool isPlayerLookingToRight = true;

    public SpriteRenderer layerChange;

    public int damage;
    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.instance.imAtacking)
        {
            activateArrowMovement();
        }
    }

    public void activateArrowMovement()
    {

        if (isPlayerLookingToRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            Destroy(gameObject, 1f);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            Destroy(gameObject, 1f);
        }

    }
}
