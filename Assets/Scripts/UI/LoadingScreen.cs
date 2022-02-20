using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject LoadingBackground;
    [SerializeField] private Animator _animator;

    private static LoadingScreen _instance;

    public static int curLoadBuildIndex = 0;

    public static LoadingScreen Instance => _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
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
        _animator.SetTrigger("LoadingFinished");
    }
}
