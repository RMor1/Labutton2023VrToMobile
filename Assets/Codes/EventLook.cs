using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLook : MonoBehaviour
{
    public AudioSource sound;
    public GameObject toEnable;
    public Rigidbody rdb;
    public Vector3 force;
    public GameObject item;
    public Text text;

    //funcao que é chamada depois de um tempo olhando
    public void ButtonAction()
    {

        if (item)
        {
            Pickup();
           
        }

        //toca o som escolhido
        if (sound)
        {
            sound.Play();
        }
        //habilita gameobjec selecionado
        if (toEnable)
        {
            toEnable.SetActive(true);
        }
        //adiciona uma força no objeto selecionado
        if (rdb)
        {
            rdb.AddForce(force,ForceMode.Impulse);
        }


    }

    //se acontece uma colisao toca o som
    private void OnCollisionEnter(Collision collision)
    {
        if (sound)
        {
            sound.Play();
        }
    }

    void Pickup()
    
    {
        /*InventaryManager.Instance.Add(item);*/
        StartCoroutine(FadingText());
        
        Debug.Log("pegou objeto");
    }

    IEnumerator FadingText()
    {
        Color newColor = text.color;
        while (newColor.a < 1)
        {
            newColor.a += Time.deltaTime;
            text.color = newColor;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        while (newColor.a > 0 )
        {
            newColor.a -= Time.deltaTime;
            text.color = newColor;
            yield return null;
        }

        item.SetActive(false);

    }

    }
