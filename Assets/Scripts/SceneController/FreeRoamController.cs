using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FreeRoamController : MonoBehaviour
{
    [SerializeField] private CarSpawnController CarSpawnController;
    [SerializeField] private ForestController ForestController;
    [SerializeField] private GameObject Litter;
    [SerializeField] private GameObject MoreLitter;
    private LoadingScreen _loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        if(SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess)
            _loadingScreen = LoadingScreen.InstanceVR;
        else 
            _loadingScreen = LoadingScreen.InstanceRegular;
        ProcessWorldState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ProcessWorldState()
    {
        CarSpawnController.SetCarSpawning();
        //If proposal approved then forest is dead
        ForestController.UpdateForestState(!WorldStateData.isForestProposalApproved);
        Litter.SetActive(!WorldStateData.isWasteProposalApproved);
        MoreLitter.SetActive(!WorldStateData.isWasteProposalApproved && WorldStateData.EnvironmentLevel<5);
    }

    public void LoadOfficeScene()
    {
        if (WorldStateData.enableElection)
        {
            _loadingScreen.LoadScene(3);
        }
        else
        {
            //Go to office
            _loadingScreen.LoadScene(1);
        }
    }
}
