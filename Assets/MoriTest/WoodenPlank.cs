using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ButtonAction()
    {
        foreach(Items itemInInventory in InventaryManager.Instance.itens)
        {
            if(itemInInventory.objectType.Equals(Items.ItemTypes.Crowbar))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.angularVelocity += new Vector3(1, 1, 1);
                break;
            }
        }
    }
}
