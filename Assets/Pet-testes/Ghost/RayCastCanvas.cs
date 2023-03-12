using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastCanvas : MonoBehaviour
{
    public RawImage imageBlood;
    public Animator imageBloodAnim;
    private float alphaBg;
    [SerializeField] private Image bg;

    void Start()
    {
       
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 6))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            

            if (hit.transform.gameObject.CompareTag("ghost"))
            {
                AlphaControl(true);
                imageBlood.enabled = true;
                imageBloodAnim.enabled = true;
                imageBloodAnim.SetBool("Volta", false);

            }
            else
            {
                AlphaControl(false);
                imageBloodAnim.SetBool("Volta", true);
                
            }
        }
    }

    private void AlphaControl(bool upAlpha)
    {
        if (alphaCoroutine != null) StopCoroutine(alphaCoroutine);
        if (upAlpha) alphaCoroutine = StartCoroutine(AlphaUp());
        else alphaCoroutine = StartCoroutine(AlphaDown());
    }
    private Coroutine alphaCoroutine;
    private IEnumerator AlphaUp()
    {
        while (true)
        {
            alphaBg += 0.0015f;
            if (alphaBg >= 0.75f)
            {
                alphaBg = 0.75f;
                bg.color = new Color(0, 0, 0, 0.75f);
                alphaCoroutine = null;
                GameOverControl.Instance.TurnOnGameOverScreen();
                yield break;
            }
            bg.color = new Color(0, 0, 0, alphaBg);
            yield return new WaitForFixedUpdate();
        }
    }
    private IEnumerator AlphaDown()
    {
        while (true)
        {
            alphaBg -= 0.002f;
            if(alphaBg <= 0)
            {
                alphaBg = 0;
                bg.color = new Color(0, 0, 0, 0);
                alphaCoroutine = null;
                yield break;
            }
            bg.color = new Color(0, 0, 0, alphaBg);
            yield return new WaitForFixedUpdate();
        }
    }

}
