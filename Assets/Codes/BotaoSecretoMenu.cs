using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoSecretoMenu : MonoBehaviour
{
    int vezesClicado;
    [SerializeField]Image img;
    public void OnPress()
    {
        vezesClicado++;
        if(vezesClicado>=5)
        {
            img.color = Color.white;
        }
    }    
}
