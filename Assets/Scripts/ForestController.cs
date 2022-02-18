using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    public bool isForestAlive = true;

    private ForestTileState[] tiles;
    // Start is called before the first frame update
    private void Awake()
    {
        tiles = GetComponentsInChildren<ForestTileState>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateForestState(bool isAlive)
    {
        isForestAlive = isAlive;
        print(tiles.Length);
        foreach (var tile in tiles)
        {
            tile.SetTileStatus(isForestAlive);
        }
    }
}
