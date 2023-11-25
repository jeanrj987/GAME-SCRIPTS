using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public SpriteRenderer layerChange;

    public float timeOfImortality;

    void Update()
    {
        if (GameController.setActiveStartSpawn)
        {
            layerChange.sortingOrder = 4;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameController.setActiveStartSpawn)
            {
                PlayerControl.instance.gameObject.transform.position = new Vector3(GameController.resPos.x, GameController.resPos.y + 5f, GameController.resPos.z);
                
                TogglePlayerMortalityToImortal();
                Invoke(nameof(TogglePlayerMortalityToMortal), timeOfImortality);
            }
        }
    }

    public void TogglePlayerMortalityToImortal()
    {
        PlayerControl.instance.gameObject.tag = "Imortal";
        PlayerControl.instance.anim.SetBool("isImortal", true);
    }
    public void TogglePlayerMortalityToMortal()
    {
        PlayerControl.instance.gameObject.tag = "Player";
        PlayerControl.instance.anim.SetBool("isImortal", false);
    }
}
