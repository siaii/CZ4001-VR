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

    public void UpdateForestState(bool isAlive)
    {
        //Update all forest tiles
        isForestAlive = isAlive;
        foreach (var tile in tiles)
        {
            tile.SetTileStatus(isForestAlive);
        }
    }
}
