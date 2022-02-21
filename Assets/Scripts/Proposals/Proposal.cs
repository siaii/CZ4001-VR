using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proposal : MonoBehaviour
{
    [SerializeField] protected float environmentEffect = -3f;
    [SerializeField] protected float happinessEffect = 3f;
    [SerializeField] private MeshRenderer processRenderer;
    [SerializeField] private Material acceptedMaterial;
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

        WorldStateData.EnvironmentLevel += environment;
        WorldStateData.EnvironmentLevel =
            Mathf.Clamp(WorldStateData.EnvironmentLevel, 0, WorldStateData.MaxEnvironmentLevel);
        WorldStateData.HappinessLevel += happiness;
        WorldStateData.HappinessLevel =
            Mathf.Clamp(WorldStateData.HappinessLevel, 0, WorldStateData.MaxEnvironmentLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stamp"))
        {
            processRenderer.material = acceptedMaterial;
            print("Proposal Stamped!");
            isApproved = true;
        }
    }
}
