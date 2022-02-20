using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    [SerializeField] private GameObject LeaveOfficeCanvas;
    private LoadingScreen loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = LoadingScreen.Instance;
        LeaveOfficeCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFreeRoamScene()
    {
        loadingScreen.LoadScene(0);
    }

    public void EnableLeaveOffice()
    {
        LeaveOfficeCanvas.SetActive(true);   
    }
}
