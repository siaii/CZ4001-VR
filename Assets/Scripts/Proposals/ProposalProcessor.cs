using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalProcessor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Proposal"))
        {
            Proposal proposal = other.gameObject.GetComponentInChildren<Proposal>();
            if (proposal)
            {
                proposal.ProcessProposal();
                Destroy(other.gameObject);
                print("Cars: " + WorldStateData.isCarProposalApproved);
                print("Waste: " + WorldStateData.isWasteProposalApproved);
                print("Forest: " + WorldStateData.isForestProposalApproved);
                print("Environment level: " + WorldStateData.EnvironmentLevel);
                print("Happiness level: " + WorldStateData.HappinessLevel);
                print("Proposal Processed!");
            }
        }
    }
}
