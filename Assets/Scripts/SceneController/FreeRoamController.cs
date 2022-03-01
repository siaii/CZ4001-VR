using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FreeRoamController : MonoBehaviour
{
    [SerializeField] private Material GoodSkyboxMat;
    [SerializeField] private Material BadSkyboxMat;
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
        
        //Set skybox material
        if (WorldStateData.EnvironmentLevel <= 4 && BadSkyboxMat)
        {
            RenderSettings.skybox = BadSkyboxMat;
        }
        else if(GoodSkyboxMat)
        {
            RenderSettings.skybox = GoodSkyboxMat;
        }
        
        ProcessWorldState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ProcessWorldState()
    {
        //Null checks
        if (CarSpawnController)
        {
            CarSpawnController.SetCarSpawning();
        }

        if (ForestController)
        {
            //If proposal approved then forest is dead
            ForestController.UpdateForestState(!WorldStateData.isForestProposalApproved);            
        }

        if (Litter)
        {
            Litter.SetActive(!WorldStateData.isWasteProposalApproved);
        }

        if (MoreLitter)
        {
            MoreLitter.SetActive(!WorldStateData.isWasteProposalApproved && WorldStateData.EnvironmentLevel<5);            
        }

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
