using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldStateData
{
    public static float EnvironmentLevel = 6; 
    public static float HappinessLevel = 6;
    public const float MaxEnvironmentLevel = 10;
    public const float MaxHappinessLevel = 10;

    public static bool isCarProposalApproved = false;
    public static bool isForestProposalApproved = false;
    public static bool isWasteProposalApproved = false;
    
    public static int officeVisitIdx = 0;
    public static bool enableElection = false;
}
