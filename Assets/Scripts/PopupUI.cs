using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    public float displayTime = 1f;

    private Coroutine routine;

    public void Show()
    {
        // Make sure the object is active BEFORE starting coroutine
        gameObject.SetActive(true);

        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine()
    {
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}
