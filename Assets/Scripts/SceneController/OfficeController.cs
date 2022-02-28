using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OfficeController : MonoBehaviour
{
    [SerializeField] private GameObject LeaveOfficeCanvas;
    [SerializeField] private GameObject ProposalLocation;
    [SerializeField] private List<GameObject> Proposals;
    private LoadingScreen _loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        if(SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess)
            _loadingScreen = LoadingScreen.InstanceVR;
        else 
            _loadingScreen = LoadingScreen.InstanceRegular;
        
        LeaveOfficeCanvas.SetActive(false);
        
        if (WorldStateData.officeVisitIdx < Proposals.Count)
        {
            Instantiate(Proposals[WorldStateData.officeVisitIdx], ProposalLocation.transform.position, ProposalLocation.transform.rotation);    
            WorldStateData.officeVisitIdx++;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFreeRoamScene()
    {
        _loadingScreen.LoadScene(0);
    }

    public void EnableLeaveOffice()
    {
        LeaveOfficeCanvas.SetActive(true);   
    }
}
