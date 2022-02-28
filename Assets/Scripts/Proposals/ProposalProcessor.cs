using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalProcessor : MonoBehaviour
{
    [SerializeField] private OfficeController officeController;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Proposal"))
        {
            print(other.gameObject.name);
            Proposal proposal = other.gameObject.GetComponentInChildren<Proposal>();
            if (proposal)
            {
                proposal.ProcessProposal();
                officeController.EnableLeaveOffice();
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
