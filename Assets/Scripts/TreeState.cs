using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState : MonoBehaviour
{
    [SerializeField] private GameObject fullTree;
    [SerializeField] private GameObject treeStump;

    private bool isTreeAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowTreeState();
    }

    void ShowTreeState()
    {
        fullTree.SetActive(isTreeAlive);
        treeStump.SetActive(!isTreeAlive);
    }

    public void SetTreeStatus(bool isAlive)
    {
        isTreeAlive = isAlive;
        ShowTreeState();
    }
}
