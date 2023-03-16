using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InventaryManager : MonoBehaviour
{
    public static InventaryManager Instance;
    public List<Items> itens = new List<Items>();

    [SerializeField] private Transform inventoryHUDParent;
    [SerializeField] private TextMeshProUGUI textUI;


    private void Awake()
    {
        Instance = this;
    }
    public void Add(Items itemToBeAdded)
    {
        itens.Add(itemToBeAdded);

        textUI.text = itemToBeAdded.objectName + " Obtained";
        textUI.enabled = true;
        Invoke("DisableTextUI", 2);
        ListItens();

    }

    private void DisableTextUI()
    {
        textUI.enabled = false;
    }

    /*public void Remove(Items slots)
    {
        itens.Remove(slots);
    }*/

    public void ListItens()
    {
        //Metodo de seguranca para garantir que o inventario so sera alterado se a quantidade de itens for alterada
        int activeItensInHud = 0;
        for (int i = 0; i < inventoryHUDParent.childCount; i++)
        {
            if (inventoryHUDParent.GetChild(i).gameObject.activeSelf)
            {
                activeItensInHud++;
            }
            else break;
        }
        // Se caso estiver mais itens no inventario a mais q itens no menu, ele modifica a image e adiciona a funcao "Use Item" qnd vc clica no button
        if(itens.Count>activeItensInHud)
        {
            GameObject slotToBeActivated = inventoryHUDParent.GetChild(activeItensInHud).gameObject;
            Image hudImage = slotToBeActivated.transform.GetChild(0).GetComponent<Image>();
            hudImage.sprite = itens[activeItensInHud].ImageItem;
            slotToBeActivated.GetComponent<Button>().onClick.AddListener(itens[activeItensInHud].UseItem);
            slotToBeActivated.SetActive(true);
        }
    }
}
