using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineItemDebbuger : MonoBehaviour
{
    private void Start()
    {
        Invoke("Debug", 2);
    }
    private void Debug()
    {
        ExamineItem.Instance.Examine(gameObject);
    }
}
