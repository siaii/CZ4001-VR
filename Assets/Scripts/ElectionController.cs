using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectionController : MonoBehaviour
{
    private Animator[] characterAnimators;

    private int isHappyHash, isAngryHash;
    // Start is called before the first frame update
    void Start()
    {
        isHappyHash = Animator.StringToHash("isHappy");
        isAngryHash = Animator.StringToHash("isAngry");
        characterAnimators = GetComponentsInChildren<Animator>();
        int boolToSet;
        if (WorldStateData.EnvironmentLevel > 4 && WorldStateData.HappinessLevel > 5)
        {
            boolToSet = isHappyHash;
        }
        else
        {
            boolToSet = isAngryHash;
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
