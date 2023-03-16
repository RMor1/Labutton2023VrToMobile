using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ExamineItem : MonoBehaviour
{
    public static ExamineItem Instance;
    [SerializeField] private GameObject postProcess;
    private Camera postProcessCam;
    [SerializeField] private CanvasGroup hudCanvasGroup;

    private GameObject objectInspected;
    int originalLayer;
    Quaternion originalRotation;
    private void Awake()
    {
        Instance = this;
        postProcessCam = postProcess.GetComponent<Camera>();
    }
    public void ExitExamine()
    {
        objectInspected.transform.rotation = originalRotation;
        objectInspected.layer = originalLayer;

        hudCanvasGroup.alpha = 0;
        hudCanvasGroup.interactable = false;
        hudCanvasGroup.blocksRaycasts = false;

        postProcess.SetActive(false);

        TouchSceenControl.Instance.enabled = true;
        StopAllCoroutines();


    }
    public void Examine(GameObject objectToBeInspected)
    {
        TouchSceenControl.Instance.StopAllCoroutines();
        TouchSceenControl.Instance.enabled = false;
        objectInspected = objectToBeInspected;
        Vector3 direction = (objectToBeInspected.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        originalRotation = objectToBeInspected.transform.rotation;
        originalLayer = objectToBeInspected.layer;
        objectToBeInspected.layer = LayerMask.NameToLayer("Focused");
        postProcessCam.nearClipPlane = Vector3.Distance(transform.position, objectInspected.transform.position) / 4.23f;
        postProcess.SetActive(true);
        hudCanvasGroup.alpha= 1;
        hudCanvasGroup.interactable= true;
        hudCanvasGroup.blocksRaycasts= true;
        StartCoroutine(ExamineItemsInputDetection());
    }

    private IEnumerator ExamineItemsInputDetection()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                OnTouchPress();
            }
            else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                OnTouchRelease();
            }
            yield return null;
        }
    }

    //Touch
    private void OnTouchPress()
    {
        Debug.Log("Touch Start");
        if (Input.touchCount <= 1)
        {
            if (onTouch == null && drag == null)
            {
                onTouch = StartCoroutine(OnTouch());
            }
        }
        else
        {
            if (onTouch != null)
            {
                StopCoroutine(onTouch);
                onTouch = null;
            }
            else if (drag != null)
            {
                DragStop();
            }
            if (pinch == null)
            {
                pinch = StartCoroutine(Pinch());
                Debug.Log("Pinch Start");
            }
        }
    }
    private void OnTouchRelease()
    {
        Debug.Log("Touch Stop");
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
        else if (Input.touchCount < 2)
        {
            if (pinch != null)
            {
                Debug.Log("Pinch Stop");
                StopCoroutine(pinch);
                pinch = null;
            }
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

    //Drag
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
            objectInspected.transform.Rotate(0, -deltaPosition.x / 10, deltaPosition.y / 10,Space.World);
            startPosition = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y);
            //rotate object
            yield return null;
        }
    }

    //Click
    private void Click()
    {
        //Ray raycast = .ScreenPointToRay(Input.touches[0].position);
        //if (Physics.Raycast(raycast.origin, raycast.direction * 10, out RaycastHit hit, 5.65f))
        //{
        //    
        //}
    }

    //Pinch
    private Coroutine pinch;
    private IEnumerator Pinch()
    {
        float lastInputTouchDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
        while (Input.touchCount >= 2)
        {
            float CurrentInputTouchDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            float deltaInput = (CurrentInputTouchDistance - lastInputTouchDistance) / 10;
            if (postProcessCam.fieldOfView - deltaInput < 20) postProcessCam.fieldOfView = 20;
            else if (postProcessCam.fieldOfView - deltaInput > 90) postProcessCam.fieldOfView = 90;
            else postProcessCam.fieldOfView -= deltaInput;
            lastInputTouchDistance = CurrentInputTouchDistance;
            yield return null;
        }
    }
}
