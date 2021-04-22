using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLuke1 : MonoBehaviour
{
    private float rotateSpeed = 50;

    private void Update()
    {
        transform.Rotate(0, 0 + rotateSpeed * Time.deltaTime, 0);
    }
}
