using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastCanvas : MonoBehaviour
{
    public Canvas canv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 6))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);


            if (hit.transform.gameObject.CompareTag("ghost"))
            {

                canv.enabled = true;

            }
            else
            {
                canv.enabled = false;
            }
        }







    }
}
