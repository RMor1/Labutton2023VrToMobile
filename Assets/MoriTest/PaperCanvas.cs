using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperCanvas : MonoBehaviour
{
    public static PaperCanvas Instance { get; private set; }
    private Image image;
    private void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();
    }

    public void SwitchOnOff()
    {
        image.enabled = !image.enabled;
    }
}
