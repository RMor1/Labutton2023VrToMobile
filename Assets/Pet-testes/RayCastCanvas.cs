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
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
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
                
            }
            else
            {
                AlphaControl(false);
                imageBlood.enabled = false;
                imageBloodAnim.enabled = false;
                imageBloodAnim.Play("Anim-normal",0,0);
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
            alphaBg += 0.002f;
            if (alphaBg >= 0.75f)
            {
                alphaBg = 0.75f;
                bg.color = new Color(0, 0, 0, 0.75f);
                alphaCoroutine = null;
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
