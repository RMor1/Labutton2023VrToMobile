using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InGamePurchaseData
{
    public bool partyMode;
    public InGamePurchaseData(InGamePurchase dataReference)
    {
        partyMode = dataReference.partyMode;
    }
    
}
