using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public bool imAtacking;
    public Animator anim;

    public bool bowEnabled;

    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }
    private void Update()
    {
        PlayerAtacks();
    }
    public void deathTrigger()
    {
        anim.SetTrigger("Death");
        GameController.instance.GameOverTrigger();
    }
    public void atackTrigger()
    {
        anim.SetTrigger("Atack");
    }
    public void PlayerAtacks()
    {
        if (Input.GetMouseButton(0))
        {
            atackTrigger();
            imAtacking = true;
        }
        if (Input.GetMouseButton(1))
        {
            if (bowEnabled)
            {
                imAtacking = true;
                ActivateArrow.instance.setArrowOn();
            }
        }
    }
}
