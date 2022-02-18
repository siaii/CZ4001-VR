using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestProposal : Proposal
{
    public override void ProcessProposal()
    {
        base.ProcessProposal();
        WorldStateData.isForestProposalApproved = isApproved;
    }
}
