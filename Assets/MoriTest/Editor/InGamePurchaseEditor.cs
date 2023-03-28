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
            inGamePurchase.partyModeBought = true;
            inGamePurchase.CreateSave();
        }
        if (GUILayout.Button("LoadSave"))
        {
            inGamePurchase.LoadSaves();
        }
        if (GUILayout.Button("ResetSave"))
        {
            inGamePurchase.partyModeBought = false;
            inGamePurchase.CreateSave();
        }
        if (GUILayout.Button("CreateSave"))
        {
            inGamePurchase.CreateSave();
        }

    }
}
