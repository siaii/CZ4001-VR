using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnLocator : MonoBehaviour
{
    private static PlayerSpawnLocator _instance;

    public static PlayerSpawnLocator Instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
