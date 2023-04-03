using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InGamePurchase))]
public class InGamePurchaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(5);
        InGamePurchase inGamePurchase = target as InGamePurchase;
        if (GUILayout.Button("LoadSave"))
        {
            inGamePurchase.LoadSaves();
        }
        GUILayout.Space(5);
        if (GUILayout.Button("ResetSave"))
        {
            inGamePurchase.partyModeBought = false;
            inGamePurchase.twoXSpeedBought = false;
            inGamePurchase.extraAssetsBought = false;

            inGamePurchase.partyModeActive = false;
            inGamePurchase.twoXSpeedActive = false;
            inGamePurchase.extraAssetsActive = false;

            inGamePurchase.Save();
        }
        GUILayout.Space(5);
        if (GUILayout.Button("CreateSave"))
        {
            inGamePurchase.Save();
        }

    }
}
