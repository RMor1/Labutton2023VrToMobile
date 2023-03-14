using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventaryManager : MonoBehaviour
{
    public static InventaryManager Instance;
    public List<Items> itens = new List<Items>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Items script;
  

    private void Awake()
    {
        Instance = this;
    }
 
    public void Add(Items slots)
    {
        itens.Add(slots);
    }

    /*public void Remove(Items slots)
    {
        itens.Remove(slots);
    }*/

    public void ListItens()
    {
        foreach(Transform slots in ItemContent)
        {
            Destroy(slots.gameObject);
        }

        foreach(var slots in itens)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
           var ImageItems = obj.transform.Find("ImageItem").GetComponent<Image>();

            ImageItems.sprite = slots.ImageItem; // errado - verificar dps
        }
    }
}
