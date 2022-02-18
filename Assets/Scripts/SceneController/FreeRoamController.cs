using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : MonoBehaviour
{
    private LoadingScreen loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = LoadingScreen.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadOfficeScene()
    {
        loadingScreen.LoadScene(1);
    }
}
