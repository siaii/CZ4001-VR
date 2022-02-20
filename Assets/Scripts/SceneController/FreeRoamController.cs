using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : MonoBehaviour
{
    [SerializeField] private CarSpawnController CarSpawnController;
    [SerializeField] private ForestController ForestController;
    [SerializeField] private GameObject Litter;
    [SerializeField] private GameObject MoreLitter;
    private LoadingScreen loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = LoadingScreen.Instance;
        ProcessWorldState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ProcessWorldState()
    {
        CarSpawnController.SetCarSpawning(WorldStateData.isCarProposalApproved);
        //If proposal approved then forest is dead
        ForestController.UpdateForestState(!WorldStateData.isForestProposalApproved);
        Litter.SetActive(!WorldStateData.isWasteProposalApproved);
        MoreLitter.SetActive(!WorldStateData.isWasteProposalApproved && WorldStateData.EnvironmentLevel<5);
    }

    public void LoadOfficeScene()
    {
        loadingScreen.LoadScene(1);
    }
}
