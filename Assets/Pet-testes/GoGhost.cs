using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGhost : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
        m_Rigidbody = GetComponent<Rigidbody>();

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

    }
    
}
