using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OfficeController : MonoBehaviour
{
    [SerializeField] private GameObject LeaveOfficeCanvas;
    private LoadingScreen _loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        if(SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess)
            _loadingScreen = LoadingScreen.InstanceVR;
        else 
            _loadingScreen = LoadingScreen.InstanceRegular;
        
        LeaveOfficeCanvas.SetActive(false);
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
