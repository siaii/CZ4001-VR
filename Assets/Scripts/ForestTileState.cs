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
    void Start()
    {
        _treeStates = treesParent.GetComponentsInChildren<TreeState>();
        SetTileStatus(isTileAlive);
    }

    // Update is called once per frame
    void Update()
    {
        
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
