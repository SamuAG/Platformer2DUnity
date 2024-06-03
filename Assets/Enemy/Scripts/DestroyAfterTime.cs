using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyAfter(1));
    }

    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
