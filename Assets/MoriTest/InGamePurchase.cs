using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePurchase : MonoBehaviour
{
    public enum BuyOptions
    {
        PartyMode,
        TwoXSpeed,
        ExtraAssets
    }
    public bool partyModeBought;
    public bool twoXSpeedBought;
    public bool extraAssetsBought;

    public bool partyModeActive;
    public bool twoXSpeedBoughtActive;
    public bool extraAssetsActive;

    [Header("Party Mode")]
    [SerializeField] private SpriteRenderer ghostVisual;
    [SerializeField] private Image ghostUI;

    [Space]

    [SerializeField] private Sprite ghostDefault;
    [SerializeField] private Sprite ghostParty;

    [Space]

    [SerializeField] private Sprite ghostDefaultUIAttack;
    [SerializeField] private Sprite ghostPartyUIAttack;

    [Header("Party Mode")]
    [SerializeField] private GameObject paintingGOParent;

    public void Awake()
    {
        if (!SaveSystem.FileExist())
        {
            CreateSave();
        }
        else
        {
            LoadSaves();
        }
        UpdateActiveAddons();
    }
    public void UpdateActiveAddons()
    {
        if (partyModeActive)
        {
            ghostVisual.sprite = ghostParty;
            ghostUI.sprite = ghostPartyUIAttack;
        }
        else
        {
            ghostVisual.sprite = ghostDefault;
            ghostUI.sprite = ghostDefaultUIAttack;
        }
        if (twoXSpeedBoughtActive)
        {
            Time.timeScale = 2;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (extraAssetsActive)
        {
            paintingGOParent.SetActive(true);

        }
        else
        {
            paintingGOParent.SetActive(false);
        }
    }
    public void CreateSave()
    {
        SaveSystem.SaveStorePurchase(this);
    }
    public void LoadSaves()
    {
        InGamePurchaseData data = SaveSystem.LoadData();
        partyModeBought = data.partyModeBought;
        twoXSpeedBought = data.twoXSpeedBought;
        extraAssetsBought = data.extraAssetsBought;

        partyModeActive = data.partyModeActive;
        twoXSpeedBoughtActive = data.twoXSpeedBoughtActive;
        extraAssetsActive = data.extraAssetsActive;
    }

    public void Buy(BuyOptions buyOption)
    {
        switch(buyOption)
        {
            case BuyOptions.PartyMode:
                partyModeBought = true;
                break;
            case BuyOptions.TwoXSpeed:
                twoXSpeedBought = true;
                break;
            case BuyOptions.ExtraAssets:
                extraAssetsBought = true;
                break;
        }
        CreateSave();
    }
}
