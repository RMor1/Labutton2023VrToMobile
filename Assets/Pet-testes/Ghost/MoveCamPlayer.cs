using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamPlayer : MonoBehaviour

{
   
    public GameObject Activateghost;
  
    public Transform tar;
    public GameObject player;
    private Transform Player;
    //float smooth = 1f;
    Vector3 Direction;

    private void Awake()
    {
        Activateghost.SetActive(false);
       

    }

    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 64 ))
        {
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* 32, Color.green);

           if (hit.transform.gameObject.CompareTag("Teste"))
            {
                /* Direction = (target.position)
                 rotacao = Quaternion.Euler(Direction);
                 Quaternion.Slerp(player.transform.rotation, rotacao, smooth);
                 Debug.Log("acertou o player");

                 Quaternion target = Quaternion.Euler(0, -180, 0). normalized;
                 player.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/

                Direction = (tar.position - player.transform.position).normalized;
                Quaternion target = Quaternion.LookRotation(Direction);
                player.transform.rotation= Quaternion.Lerp(transform.rotation , target, Time.fixedDeltaTime * 50);

                StartCoroutine(JumpGhost());
               

               
            }
        }

        IEnumerator JumpGhost()
        {
            yield return new WaitForSeconds(0.2f);

            Activateghost.SetActive(true);



        }
    }  
}
