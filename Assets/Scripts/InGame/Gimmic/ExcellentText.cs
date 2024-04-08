using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcellentText : MonoBehaviour
{
    private IEnumerator ActiveFalse()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
       StartCoroutine(ActiveFalse());
    }
}
