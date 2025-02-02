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
    public bool twoXSpeedActive;
    public bool extraAssetsActive;

    [Header("Party Mode")]
    [SerializeField] private SpriteRenderer ghostVisual;
    [SerializeField] private Animator ghostUI;

    [Space]

    [SerializeField] private Sprite ghostDefault;
    [SerializeField] private Sprite ghostParty;

    [Space]

    [SerializeField] private RuntimeAnimatorController ghostDefaultUIAttack;
    [SerializeField] private RuntimeAnimatorController ghostPartyUIAttack;

    [Header("Extra Paint Mode")]
    [SerializeField] private GameObject paintingGOParent;

    public void Awake()
    {
        if (!SaveSystem.FileExist())
        {
            Save();
        }
        else
        {
            LoadSaves();
        }
        UpdateStoreUI();
        UpdateActiveAddons();
    }
    public void UpdateActiveAddons()
    {
        if (partyModeActive)
        {
            ghostVisual.sprite = ghostParty;
            ghostUI.runtimeAnimatorController = ghostPartyUIAttack;
        }
        else
        {
            ghostVisual.sprite = ghostDefault;
            ghostUI.runtimeAnimatorController = ghostDefaultUIAttack;
        }
        if (twoXSpeedActive)
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
    public void Save()
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
        twoXSpeedActive = data.twoXSpeedActive;
        extraAssetsActive = data.extraAssetsActive;
    }
    public void Buy(int buyOptionIndex)
    {
        switch (buyOptionIndex)
        {
            case 0:
                partyModeBought = true;
                TooglePartyModeActive(true);
                break;
            case 1:
                twoXSpeedBought = true;
                ToogleTwoXSpeedBoughtActive(true);
                break;
            case 2:
                extraAssetsBought = true;
                ToogleExtraAssetsBought(true);
                break;
        }
        Save();
    }
    public void TooglePartyModeActive(bool toggle)
    {
        partyModeActive = toggle;
        UpdateActiveAddons();
    }
    public void ToogleTwoXSpeedBoughtActive(bool toggle)
    {
        twoXSpeedActive = toggle;
        UpdateActiveAddons();
    }
    public void ToogleExtraAssetsBought(bool toggle)
    {
        extraAssetsActive = toggle;
        UpdateActiveAddons();
    }
    [Space]
    [SerializeField] private GameObject partyModeButtonBuy;
    [SerializeField] private GameObject partyModeToggle;
    [Space]
    [SerializeField] private GameObject twoXSpeedButtonBuy;
    [SerializeField] private GameObject twoXSpeedToggle;
    [Space]
    [SerializeField] private GameObject extraAssetsButtonBuy;
    [SerializeField] private GameObject extraAssetsToggle;
    public void UpdateStoreUI()
    {
        if (partyModeBought)
        {
            partyModeButtonBuy.SetActive(false);
            partyModeToggle.SetActive(true);
        }
        else if (partyModeActive)
        {
            partyModeToggle.GetComponent<Toggle>().isOn = true;
        }
        if (twoXSpeedBought)
        {
            twoXSpeedButtonBuy.SetActive(false);
            twoXSpeedToggle.SetActive(true);

        }
        else if (twoXSpeedActive)
        {
            twoXSpeedToggle.GetComponent<Toggle>().isOn = true;
        }
        if (extraAssetsBought)
        {
            extraAssetsButtonBuy.SetActive(false);
            extraAssetsToggle.SetActive(true);
        }
        else if (extraAssetsActive)
        {
            extraAssetsToggle.GetComponent<Toggle>().isOn = true;
        }
    }
}
