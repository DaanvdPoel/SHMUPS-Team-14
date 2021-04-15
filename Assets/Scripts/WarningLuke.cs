using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLuke : MonoBehaviour
{
    [SerializeField] private GameObject tentacle;
    private Vector3 tentPos;
    private Quaternion tentRot;

    void Start()
    {
        if (gameObject.CompareTag("AreaWarn"))
        {
            StartCoroutine(WarnDestroyArea());
        }
        else
        {
            StartCoroutine(WarnDestroy());
        }
    }

    private IEnumerator WarnDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private IEnumerator WarnDestroyArea()
    {
        yield return new WaitForSeconds(7f);
        SummonTentacle();
        Destroy(gameObject);
    }

    private void SummonTentacle()
    {
        tentPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        tentRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        Instantiate(tentacle, tentPos, tentRot);
    }
}
