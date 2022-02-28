using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int firstSceneIndex = 0;

    private LoadingScreen _loadingScreen;
    private static GameController _instance;

    public static GameController Instance => _instance;
    public GameObject player => Player;
    private bool init = false;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SteamVR.initializedState != SteamVR.InitializedStates.InitializeSuccess)
        {
            DontDestroyOnLoad(Player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //So it only runs once and not immediately upon start and the fade anim plays
        if (!init && Time.time > 0.5f)
        {
            if(SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess)
                _loadingScreen = LoadingScreen.InstanceVR;
            else 
                _loadingScreen = LoadingScreen.InstanceRegular;


            _loadingScreen.LoadScene(firstSceneIndex);
            init = true;
        }
    }

    public void MovePlayerToSpawnLoc(Transform tf)
    {
        Player.transform.position = tf.position;
        Player.transform.rotation = tf.rotation;
        //To reset the camera to player location. Basically turn off and turn on again
        Player.SetActive(false);
        Player.SetActive(true);
    }


}
