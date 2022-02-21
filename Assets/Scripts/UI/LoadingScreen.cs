using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject LoadingBackground;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool isVR;

    private static LoadingScreen _instanceVR;
    private static LoadingScreen _instanceRegular;

    public static int curLoadBuildIndex = 0;

    public static LoadingScreen InstanceVR => _instanceVR;
    public static LoadingScreen InstanceRegular => _instanceRegular;

    private void Awake()
    {
        if (isVR)
        {
            if (_instanceVR == null)
            {
                _instanceVR = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (_instanceRegular == null)
            {
                _instanceRegular = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadingBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int buildIndex)
    {
        LoadingBackground.SetActive(true);
        curLoadBuildIndex = buildIndex;
    }

    public void WaitForLoadFinish(AsyncOperation op)
    {
        StartCoroutine(WaitForLoadFinishCoroutine(op));
    }

    private IEnumerator WaitForLoadFinishCoroutine(AsyncOperation op)
    {
        yield return new WaitUntil(() => op.isDone);
        yield return new WaitForSeconds(1f);
        PlayerSpawnLocator loc = FindObjectOfType<PlayerSpawnLocator>();
        if (loc != null)
        {
            GameController.Instance.MovePlayerToSpawnLoc(loc.transform);            
        }

        _animator.SetTrigger("LoadingFinished");
    }
}
