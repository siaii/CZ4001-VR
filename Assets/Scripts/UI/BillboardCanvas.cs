using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;

    private void Start()
    {
        mainCam = GameController.Instance.player;
    }

    void LateUpdate()
    {
        if (mainCam)
        {
            Vector3 pos = new Vector3(mainCam.transform.position.x, transform.position.y, mainCam.transform.position.z);
            transform.LookAt(transform.position + Vector3.Normalize(transform.position - pos));            
        }
    }
}
