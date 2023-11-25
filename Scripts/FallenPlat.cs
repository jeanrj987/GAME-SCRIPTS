using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class FallenPlat : MonoBehaviour
{
    public float fallingTime;

    public TargetJoint2D target;

    public ParticleSystem fallenPlatParticles;

    private void Start()
    {
        target = GetComponent<TargetJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Fall), fallingTime);
        }
    }
    private void Fall()
    {
        target.enabled = false;

        if (fallenPlatParticles != null)
        {
            var emissionModule = fallenPlatParticles.emission;
            emissionModule.enabled = false;
        }
        else
        {
            Debug.LogWarning("ParticleSystem is not assigned to fallenPlatParticles cause plat has alredy fall.");
        }
    }
}
