using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetect : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            MovePlayer.instance.isJumping = false;
            MovePlayer.instance.anim.SetBool("Jump", false);
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            MovePlayer.instance.isJumping = true;
        }
    }
}
