using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InGamePurchaseData
{
    public bool partyModeBought;
    public InGamePurchaseData(InGamePurchase dataReference)
    {
        partyModeBought = dataReference.partyModeBought;
    }
    
}
