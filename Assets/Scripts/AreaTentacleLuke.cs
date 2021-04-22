using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTentacleLuke : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyTentacle());
    }
    private IEnumerator DestroyTentacle()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
