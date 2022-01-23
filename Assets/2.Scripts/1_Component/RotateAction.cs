using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAction : MonoBehaviour
{
    private void Start() {
        StartCoroutine("Rotate");
    }

    IEnumerator Rotate()
    {
        while(true)
        {
            transform.Rotate(45.0f * Vector3.up);
            yield return new WaitForSeconds(0.3f);
        }
    }
}