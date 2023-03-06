using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGhost : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    BoxCollider m_boxCollider;
    float speed = 4f;
    public GameObject obj;
    // Start is called before the first frame update
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_boxCollider = GetComponent<BoxCollider>();

        m_Rigidbody.velocity = transform.forward * speed;
    }
    private void Start()
    {
        StartCoroutine(Freeze());
    }


    IEnumerator Freeze()
    {
        yield return  new WaitForSeconds (0.2f);
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        m_boxCollider.enabled = true;

        yield return new WaitForSeconds(10f);

        obj.SetActive(false);

    }
    
}
