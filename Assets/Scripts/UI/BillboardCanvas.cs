using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;

    private void Awake()
    {
        
    }

    void LateUpdate()
    {
        if(mainCam)
            transform.LookAt(transform.position + Vector3.Normalize(transform.position - mainCam.transform.position) );
    }
}
