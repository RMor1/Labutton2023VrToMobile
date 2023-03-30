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
    public bool twoXSpeedBoughtActive;
    public bool extraAssetsActive;
    public InGamePurchaseData(InGamePurchase dataReference)
    {
        partyModeBought = dataReference.partyModeBought;
        twoXSpeedBought = dataReference.twoXSpeedBought;
        extraAssetsBought = dataReference.extraAssetsBought;

        partyModeActive = dataReference.partyModeActive;
        twoXSpeedBoughtActive = dataReference.twoXSpeedBoughtActive;
        extraAssetsActive = dataReference.extraAssetsActive;
    }

}
