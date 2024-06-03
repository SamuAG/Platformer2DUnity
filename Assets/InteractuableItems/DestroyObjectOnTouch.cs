using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnTouch : MonoBehaviour
{
    [SerializeField] AudioSource audioPrefab;
    [SerializeField] AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // Add a coin or something
            if (audioPrefab != null)
            {
                AudioSource temp = Instantiate(audioPrefab, transform.position, Quaternion.identity);
                temp.clip = audioClip;
                temp.Play();
            }
            Destroy(gameObject);
        }
    }
}
