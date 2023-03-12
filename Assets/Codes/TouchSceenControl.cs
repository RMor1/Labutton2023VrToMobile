using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSceenControl : MonoBehaviour
{
    public static TouchSceenControl Instance { get;private set; }
    [SerializeField] private FPSWalk fpswalk;
    private Camera mainCam;
    private void Awake()
    {
        Instance= this;
        mainCam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTouchPress();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchRelease();
        }
    }
    private void OnTouchPress()
    {
        if (onTouch == null && drag == null)
        {
            onTouch = StartCoroutine(OnTouch());
            Debug.Log("StartTouch");
        }
    }
    private void OnTouchRelease()
    {
        if (onTouch != null)
        {
            StopCoroutine(onTouch);
            onTouch = null;
            Click();
        }
        else if (drag != null)
        {
            DragStop();
        }
    }
    private Coroutine onTouch;
    private IEnumerator OnTouch()
    {
        Vector2 startPosition = Input.touches[0].position;
        Vector2 deltaPosition;
        float timer = 0;
        while (timer < 0.5f)
        {
            deltaPosition = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y) - startPosition;
            if (Mathf.Abs(deltaPosition.x) + Mathf.Abs(deltaPosition.y) > 50)
            {
                break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        DragStart();
        onTouch = null;
    }

    private void DragStart()
    {
        if (drag == null) drag = StartCoroutine(Drag());
    }
    private void DragStop()
    {
        if (drag != null)
        {
            StopCoroutine(drag);
            drag = null;
        }
    }

    private Coroutine drag;
    private IEnumerator Drag()
    {
        Vector2 startPosition = Input.touches[0].position;
        while (true)
        {
            Vector2 deltaPosition = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y) - startPosition;
            Vector3 neckmov = new Vector3(-deltaPosition.y/5.5f, 0, 0);
            transform.Rotate(neckmov);
            Vector3 bodymov = new Vector3(0, deltaPosition.x/ 5.5f, 0);
            transform.parent.Rotate(bodymov);
            startPosition = Input.touches[0].position;
            yield return null;
        }
    }
    private void Click()
    {
        Ray raycast = mainCam.ScreenPointToRay(Input.touches[0].position);
        if (Physics.Raycast(raycast.origin, raycast.direction * 10, out RaycastHit hit, 5.65f))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                hit.transform.gameObject.SendMessageUpwards("ButtonAction");
            }
            else if (hit.transform.gameObject.CompareTag("Walkable"))
            {
                fpswalk.positionToGo = hit.transform.position;
            }
            else if(hit.transform.gameObject.CompareTag("Examinable"))
            {
                ExamineItem.Instance.Examine(hit.transform.gameObject);
            }
        }
    }
}
