using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllTutoBoxes : MonoBehaviour
{
    public GameObject disableTarget;
    public GameObject enableTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) DisabaleThisTuto(disableTarget, enableTarget);
    }

    void DisabaleThisTuto(GameObject disbableThis, GameObject enableThis)
    {
        enableThis.SetActive(true);
        disbableThis.SetActive(false);
    }

}
