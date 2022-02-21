using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneLoadOnFinish : StateMachineBehaviour
{
    private LoadingScreen _loadingScreen;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        if(SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess)
            _loadingScreen = LoadingScreen.InstanceVR;
        else 
            _loadingScreen = LoadingScreen.InstanceRegular;
        var loadOp = SceneManager.LoadSceneAsync(LoadingScreen.curLoadBuildIndex);
        _loadingScreen.WaitForLoadFinish(loadOp);
    }
}
