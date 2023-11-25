using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackActivator : MonoBehaviour
{
    public BoxCollider2D hitBoxAtack;
    // Start is called before the first frame update
    void Start()
    {
        hitBoxAtack = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovePlayer.movement > 0)
        {
            hitBoxAtack.offset = new Vector2(0.6f, 0);
        }
        else
        {
            hitBoxAtack.offset = new Vector2(-0.6f, 0);
        }
    }
}
