using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspector : MonoBehaviour
{
    public void InspectItem(GameObject objectToBeInspected)
    {
        MeshRenderer m_meshRenderer = new MeshRenderer(); // adiconar o valor de var

        StartCoroutine(EnterInspectModeObject(m_meshRenderer));
    }
    private IEnumerator EnterInspectModeObject(MeshRenderer meshRenderer)
    {
        //Mover objeto ate zona de inspecao baseado no tamanho do objeto
        yield return null;
    }

    private IEnumerator InspectingItems()
    {
        yield return null;
    }
}
