using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float amplitude = 0.001f;

    void FixedUpdate()
    {
        // sinusoide movement
        transform.position += new Vector3(0, Mathf.Sin(Time.time * speed) * amplitude, 0);
    }
}
