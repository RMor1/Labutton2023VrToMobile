using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WoodenPlank : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ButtonAction()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.angularVelocity += new Vector3(1, 1, 1);
    }
}
