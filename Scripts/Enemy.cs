using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public float speed;
    public float moveTime;

    public bool dirRight;
    private float timer;

    private Vector3 originalScale;

    private Animator anim;

    public Transform headPoint;

    public int enemyLife;

    void Start()
    {
        originalScale = transform.localScale;
        anim = GetComponent<Animator>();

        instance = this;
    }
 
    void Update()
    {
        EnemyMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) dirRight = !dirRight;

        float height = collision.contacts[0].point.y - headPoint.position.y;

        Vector2 hitDirection = collision.contacts[0].point - (Vector2)transform.position;

        TriggerForDiscount("Arrow", 1, true);

        if (enemyLife <= 0)
        {
            isEnemyDead();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (height > 0f)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                isEnemyDead();
            }
            else
            {
                if (hitDirection.x > 0 && !dirRight)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
                if (hitDirection.x < 0 && dirRight)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }

                anim.SetTrigger("isAtacking");
                collision.gameObject.tag = "deathPlayer";
                Destroy(collision.gameObject, 0.5f);

                PlayerControl.instance.deathTrigger();
            }
        }

        void TriggerForDiscount(string nameOfWeapon, int damage, bool destroyThat)
        {
            if (collision.gameObject.CompareTag(nameOfWeapon))
            {
                anim.SetTrigger("TakingHit");
                DiscountLife(damage);

                if (destroyThat) Destroy(collision.gameObject);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hit"))
        {
            DiscountLife(3);

            if (enemyLife <= 0) isEnemyDead();
        }
    }

    public void DiscountLife(int damage)
    {
        enemyLife -= damage;
    }

    public void isEnemyAlive()
    {
        if (enemyLife <= 0)
        {
            isEnemyDead();
        }
    }

    public void isEnemyDead()
    {
        gameObject.tag = "deathEnemy";

        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        anim.SetTrigger("Death");

        Destroy(gameObject, 0.6f);
        speed = 0f;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    public void EnemyMove()
    {
        anim.SetTrigger("Walk");

        if (speed == 0) anim.SetTrigger("Iddle");

        if (!dirRight)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}