using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    public static GameOverControl Instance;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        Instance = this;
        canvasGroup= GetComponent<CanvasGroup>();
    }
    public void TurnOnGameOverScreen()
    {
        StartCoroutine(AlphaCanvasGroupIncrease());
    }
    private IEnumerator AlphaCanvasGroupIncrease()
    {
        TouchSceenControl.Instance.enabled = false;
        TouchSceenControl.Instance.StopAllCoroutines();
        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += 0.02f;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.alpha= 1;
        canvasGroup.interactable= true;
    }
}
