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
        //teleporta o objeto pra longe pq o destroy tem um delay e pode causar uma leve demora 
        transform.position = new Vector3(2000, 2000, 2000);
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
