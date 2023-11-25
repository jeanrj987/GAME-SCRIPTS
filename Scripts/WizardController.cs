using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    private Vector3 originalScale;

    private Animator anim;

    public float timer;
    public float moveTime;

    public float speed;
    public float previusSpeed;

    public int enemyLife;

    public bool dirRight = true;

    public BoxCollider2D left;
    public BoxCollider2D right;


    public GameObject childreenGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        anim = GetComponent<Animator>();

        previusSpeed = speed;
    }
    void Update()
    {
        WizardMove();

        isEnemyAlive();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 relativePosition = collision.transform.position - transform.position;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (relativePosition.x < 0 && dirRight) dirRight = !dirRight;
            if (relativePosition.x > 0 && !dirRight) dirRight = !dirRight;
            SetAtackOn();
            KillPlayer(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        anim.SetBool("isAtacking", false);
        speed = previusSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerForDiscount("Arrow", 1, true);

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
    void WizardMove()
    {
        anim.SetTrigger("Walk");

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

    void SetAtackOn()
    {
        anim.SetBool("isAtacking", true);

        if (anim.GetBool("isAtacking") == true)
        {
            speed = 0;
        }
    }

    void KillPlayer(GameObject gameObject)
    {
        gameObject.tag = "deathPlayer";
        Destroy(gameObject, 0.5f);

        PlayerControl.instance.deathTrigger();
    }

    public void isEnemyDead()
    {
        gameObject.tag = "deathEnemy";

        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        anim.SetTrigger("Death");
        Destroy(gameObject, 0.6f);
        speed = 0f;

        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        left.enabled = false; 
        right.enabled = false;
        
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
}
