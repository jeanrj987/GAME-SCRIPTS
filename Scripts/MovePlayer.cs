using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public static MovePlayer instance;

    public float speed;

    private Rigidbody2D rig;
    public Animator anim;

    public CapsuleCollider2D collisor;

    public bool isJumping;
    public float jumpForce;

    public bool doubleJumpEnable;

    public static float movement;
    // Start is called before the first frame update
    void Start()
    {
        instance  = this;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {

        movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2 (movement * speed, rig.velocity.y );

        if (movement == 0)
        {
            anim.SetBool("Walk", false);
        } else if (movement > 0) 
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("Walk", true);

            Arrow.isPlayerLookingToRight = true;
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Walk", true);

            Arrow.isPlayerLookingToRight = false;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJumpEnable = true;
                anim.SetBool("Jump", true);
            }
            else
            {
                if (doubleJumpEnable)
                {
                    rig.AddForce(new Vector2(0f , jumpForce * 1.5f), ForceMode2D.Impulse);
                    doubleJumpEnable = false;
                    anim.SetBool("Jump", true);
                }
            }
        }
    }
}
