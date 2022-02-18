using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proposal : MonoBehaviour
{
    [SerializeField] protected float environmentEffect = -3f;
    [SerializeField] protected float happinessEffect = 3f;
    
    public bool isApproved
    {
        get;
        protected set;
    } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ProcessProposal()
    {
        float environment = environmentEffect;
        float happiness = happinessEffect;
        if (!isApproved)
        {
            environment *= -1;
            happiness *= -1;
        }

        WorldStateData.EnvironmentLevel += Mathf.Clamp(environment, 0, WorldStateData.MaxEnvironmentLevel);
        WorldStateData.HappinessLevel += Mathf.Clamp(happiness, 0, WorldStateData.MaxHappinessLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stamp"))
        {
            print("Proposal Stamped!");
            isApproved = true;
        }
    }
}
