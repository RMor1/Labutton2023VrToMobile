using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InGamePurchase))]
public class InGamePurchaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        InGamePurchase inGamePurchase = target as InGamePurchase;
        if(GUILayout.Button("BuyItem"))
        {
            inGamePurchase.partyMode = true;
            inGamePurchase.Purchase();
        }
        if (GUILayout.Button("LoadSave"))
        {
            inGamePurchase.LoadSaves();
        }
        if (GUILayout.Button("ResetSave"))
        {
            inGamePurchase.partyMode = false;
            inGamePurchase.Purchase();
        }
    }
}
