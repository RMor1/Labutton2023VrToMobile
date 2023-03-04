using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGhost : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    BoxCollider m_boxCollider;
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
        m_Rigidbody = GetComponent<Rigidbody>();
        m_boxCollider = GetComponent<BoxCollider>();

        m_Rigidbody.velocity = transform.forward * speed;


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        yield return  new WaitForSeconds (0.2f);
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        m_boxCollider.enabled = true;

    }
    
}
