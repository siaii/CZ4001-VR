using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteProposal : Proposal
{
    public override void ProcessProposal()
    {
        base.ProcessProposal();
        WorldStateData.isWasteProposalApproved = isApproved;
    }
}
