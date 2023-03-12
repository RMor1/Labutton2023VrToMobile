using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items item;
    // Start is called before the first frame update
    void Pickup()
    {
        InventaryManager.Instance.Add(item);
        Destroy(gameObject);
        Debug.Log("ativada");
    }

   public void ButtonAction()
    {
        if (item)
        {
            Debug.Log("interação");
            Pickup();
        }
           
    }
}
