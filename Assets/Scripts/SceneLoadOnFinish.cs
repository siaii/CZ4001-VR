using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadOnFinish : StateMachineBehaviour
{
    private LoadingScreen _loadingScreen;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        _loadingScreen = LoadingScreen.Instance;
        var loadOp = SceneManager.LoadSceneAsync(LoadingScreen.curLoadBuildIndex);
        _loadingScreen.WaitForLoadFinish(loadOp);
    }
}
