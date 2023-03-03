using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject GhostRayCast;
    public GameObject player;
 
    // Start is called before the first frame update
    void Start()
    {
        GhostRayCast.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.layer == 7)
        {
            GhostRayCast.SetActive(true);
            StartCoroutine(GhostRayCastDesactive());
        }
    }

    IEnumerator GhostRayCastDesactive()
    {
    yield return new WaitForSeconds(2);
        GhostRayCast.SetActive(false);
    }
}
