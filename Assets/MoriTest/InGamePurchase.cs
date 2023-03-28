using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePurchase : MonoBehaviour
{
    public bool partyModeBought;

    public void CreateSave()
    {
        SaveSystem.SaveStorePurchase(this);
    }
    public void LoadSaves()
    {
        InGamePurchaseData data = SaveSystem.LoadData();
        partyModeBought = data.partyModeBought;
    }
}
