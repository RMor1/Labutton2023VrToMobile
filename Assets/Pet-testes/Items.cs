using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//add a propriedade na classe de criação da unity
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Items : ScriptableObject
{
    public enum ItemTypes
    {
        Key,Crowbar,Paper
    }
    public ItemTypes objectType;
    public String objectName;
    public Sprite ImageItem;
   

    

}





