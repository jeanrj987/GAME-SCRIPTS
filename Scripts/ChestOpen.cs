using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Animator anim;
    public int coinReward;

    public float timeToRewardUpdate;

    public bool chestIsOpen;

    public ParticleSystem chestParticles;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!chestIsOpen)
        {
        if (collider.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsOpened", true);
            GameController.instance.coinScore += coinReward;
            Invoke(nameof(UpdateCallFunc), timeToRewardUpdate);
            chestIsOpen = true;

            var emissionModule = chestParticles.emission;
            emissionModule.enabled = true;
            }
        }
    }

    private void UpdateCallFunc()
    {
        GameController.instance.CoinScoreUpdate();
    }
}
