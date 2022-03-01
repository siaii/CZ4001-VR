using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectionController : MonoBehaviour
{
    [SerializeField] private Material GoodSkyboxMat;
    [SerializeField] private Material BadSkyboxMat;

    [SerializeField] private GameObject WinText;
    [SerializeField] private GameObject LoseText;
    
    private Animator[] characterAnimators;

    private int isHappyHash, isAngryHash;
    // Start is called before the first frame update
    void Start()
    {
        isHappyHash = Animator.StringToHash("isHappy");
        isAngryHash = Animator.StringToHash("isAngry");
        characterAnimators = GetComponentsInChildren<Animator>();
        int boolToSet;
        //Set skybox material
        if (WorldStateData.EnvironmentLevel <= 4 && BadSkyboxMat)
        {
            RenderSettings.skybox = BadSkyboxMat;
        }
        else if(GoodSkyboxMat)
        {
            RenderSettings.skybox = GoodSkyboxMat;
        }
        
        //Set people's animation and win/lose text
        if (WorldStateData.EnvironmentLevel > 4 && WorldStateData.HappinessLevel > 5)
        {
            boolToSet = isHappyHash;
            WinText.SetActive(true);
            LoseText.SetActive(false);
        }
        else
        {
            boolToSet = isAngryHash;
            WinText.SetActive(false);
            LoseText.SetActive(true);
        }
        foreach (var animator in characterAnimators)
        {
            animator.SetBool(boolToSet, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
