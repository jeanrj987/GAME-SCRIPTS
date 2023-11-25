using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArrow : MonoBehaviour
{
    public static ActivateArrow instance;
    
    public Transform arrow;
    public Transform pivotPosition;


    public bool isShoting;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        CheckfireEnable();
    }
    public void setArrowOn()
    {
        if (!isShoting)
        {
            Instantiate(arrow, pivotPosition.position, transform.rotation);
        }
    }
    public void CheckfireEnable()
    {
        isShoting = GameObject.FindWithTag("Arrow") ? true : false;
    }
}
