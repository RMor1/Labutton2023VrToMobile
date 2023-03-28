using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePurchase : MonoBehaviour
{
    public bool partyMode;
    public void Purchase()
    {
        SaveSystem.SaveStorePurchase(this);
    }
    public void LoadSaves()
    {
        InGamePurchaseData data = SaveSystem.LoadData();
        partyMode = data.partyMode;
    }
}
