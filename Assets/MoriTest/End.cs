using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public static End Instance;
    [SerializeField] private Image fadeImage;
    private void Awake()
    {
        Instance = this;
    }
    public int planksActive = 3;
    public void ButtonAction()
    {
        if (planksActive <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            TouchSceenControl.Instance.fpswalk.positionToGo = transform.position;
            StartCoroutine(EndFade());
        }
    }
    private IEnumerator EndFade()
    {
        while (fadeImage.color.a < 1)
        {
            fadeImage.color = new Color(1, 1, 1, fadeImage.color.a + 0.05f);
            yield return new WaitForFixedUpdate();
        }
    }
}
