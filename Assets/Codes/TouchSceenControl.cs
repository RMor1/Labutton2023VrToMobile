using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSceenControl : MonoBehaviour
{
    [SerializeField] private FPSWalk fpswalk;
    private Camera mainCam;
    bool touchedObjOnThisClick;
    private void Awake()
    {
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
        //if (Input.GetMouseButton(0))
        //{
        //    if (!touchedObjOnThisClick)
        //    {
        //        Ray raycast = mainCam.ScreenPointToRay(Input.mousePosition);
        //        if (Physics.Raycast(raycast.origin, raycast.direction * 10, out RaycastHit hit, 5.4f))
        //        {
        //            touchedObjOnThisClick = true;
        //            if (hit.transform.gameObject.CompareTag("Player"))
        //            {
        //                hit.transform.gameObject.SendMessageUpwards("ButtonAction");
        //            }
        //            else if (hit.transform.gameObject.CompareTag("Walkable"))
        //            {
        //                fpswalk.positionToGo = hit.transform.position;
        //            }
        //            else if (inputTouch.phase == TouchPhase.Moved)
        //            {
        //                if (Mathf.Abs(inputTouch.deltaPosition.x) + Mathf.Abs(inputTouch.deltaPosition.y) > 5 || inputTouch.deltaTime > 0.5f)
        //                {
        //                    Vector3 neckmov = new Vector3(inputTouch.deltaPosition.y, 0, 0);
        //                    transform.Rotate(neckmov);
        //                    Vector3 bodymov = new Vector3(0, inputTouch.deltaPosition.x, 0);
        //                    transform.parent.Rotate(bodymov);
        //                }
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    touchedObjOnThisClick = false;
        //}
    }
    private void OnTouchPress()
    {
        if (onTouch == null && drag == null)
        {
            onTouch = StartCoroutine(OnTouch());
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
        else
        {
            DragStop();
        }
    }
    private Coroutine onTouch;
    private IEnumerator OnTouch()
    {
        Vector2 startPosition = Input.mousePosition;
        Vector2 deltaPosition;
        float timer = 0;
        while (timer < 0.5f)
        {
            deltaPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - startPosition;
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
        Vector2 startPosition = Input.mousePosition;
        while (true)
        {
            Vector2 deltaPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - startPosition;
            Vector3 neckmov = new Vector3(deltaPosition.y/5, 0, 0);
            transform.Rotate(neckmov);
            Vector3 bodymov = new Vector3(0, -deltaPosition.x/5, 0);
            transform.parent.Rotate(bodymov);
            startPosition = Input.mousePosition;
            yield return null;
        }
    }
    private void Click()
    {
        Ray raycast = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast.origin, raycast.direction * 10, out RaycastHit hit, 5.65f))
        {
            touchedObjOnThisClick = true;
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                hit.transform.gameObject.SendMessageUpwards("ButtonAction");
            }
            else if (hit.transform.gameObject.CompareTag("Walkable"))
            {
                fpswalk.positionToGo = hit.transform.position;
            }
        }
    }
}
