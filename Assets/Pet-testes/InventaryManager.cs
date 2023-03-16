using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventaryManager : MonoBehaviour
{
    public static InventaryManager Instance;
    public List<Items> itens = new List<Items>();

    [SerializeField] private Transform inventoryHUDParent;


    private void Awake()
    {
        Instance = this;
    }

    public void Add(Items itemToBeAdded)
    {
        itens.Add(itemToBeAdded);
        ListItens();

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
            hudImage.SetNativeSize();
            slotToBeActivated.GetComponent<Button>().onClick.AddListener(itens[activeItensInHud].UseItem);
            Debug.Log(activeItensInHud);
            slotToBeActivated.SetActive(true);
        }
    }
}
