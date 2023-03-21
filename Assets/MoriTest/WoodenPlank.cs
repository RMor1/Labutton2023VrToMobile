using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : MonoBehaviour
{
    private Rigidbody rb;
    private bool removed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ButtonAction()
    {
        if (!removed)
        {
            foreach (Items itemInInventory in InventaryManager.Instance.itens)
            {
                if (itemInInventory.objectType.Equals(Items.ItemTypes.Crowbar))
                {
                    rb.constraints = RigidbodyConstraints.None;
                    rb.angularVelocity += new Vector3(1, 1, 1);
                    End.Instance.planksActive--;
                    if (End.Instance.planksActive <= 0) End.Instance.GetComponent<BoxCollider>().enabled = true;
                    removed = true;
                    break;
                }
            }
        }
    }
}
