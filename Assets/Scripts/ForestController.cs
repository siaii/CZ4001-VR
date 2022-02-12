using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    public bool isForestAlive = true;

    private ForestTileState[] tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = GetComponentsInChildren<ForestTileState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateForestState(bool isAlive)
    {
        isForestAlive = isAlive;
        foreach (var tile in tiles)
        {
            tile.SetTileStatus(isForestAlive);
        }
    }
}
