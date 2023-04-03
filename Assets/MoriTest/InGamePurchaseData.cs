using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InGamePurchaseData
{
    public bool partyModeBought; 
    public bool twoXSpeedBought;
    public bool extraAssetsBought;

    public bool partyModeActive;
    public bool twoXSpeedActive;
    public bool extraAssetsActive;
    public InGamePurchaseData(InGamePurchase dataReference)
    {
        partyModeBought = dataReference.partyModeBought;
        twoXSpeedBought = dataReference.twoXSpeedBought;
        extraAssetsBought = dataReference.extraAssetsBought;

        partyModeActive = dataReference.partyModeActive;
        twoXSpeedActive = dataReference.twoXSpeedActive;
        extraAssetsActive = dataReference.extraAssetsActive;
    }

}
