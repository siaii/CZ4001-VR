using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTileState : MonoBehaviour
{
    [SerializeField] private GameObject treesParent;
    [SerializeField] private GameObject grassTile;
    [SerializeField] private GameObject dirtTile;

    public bool isTileAlive = true;
    
    private TreeState[] _treeStates;

    private void Awake()
    {
        _treeStates = treesParent.GetComponentsInChildren<TreeState>();
    }

    void Start()
    {
        SetTileStatus(isTileAlive);
    }

    public void SetTileStatus(bool isAlive)
    {
        isTileAlive = isAlive;
        foreach (var t in _treeStates)
        {
            t.SetTreeStatus(isTileAlive);
        }
        grassTile.SetActive(isTileAlive);
        dirtTile.SetActive(!isTileAlive);
    }
}
