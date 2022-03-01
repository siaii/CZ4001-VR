using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthModelController : MonoBehaviour
{
    [SerializeField] private GameObject treeParent;
    [SerializeField] private GameObject buildingParent;
    
    // Start is called before the first frame update
    void Start()
    {
        buildingParent.SetActive(WorldStateData.isForestProposalApproved);
        treeParent.SetActive(!WorldStateData.isForestProposalApproved);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
