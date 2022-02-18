using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProposal : Proposal
{
    public override void ProcessProposal()
    {
        base.ProcessProposal();
        WorldStateData.isCarProposalApproved = isApproved;
    }
}
