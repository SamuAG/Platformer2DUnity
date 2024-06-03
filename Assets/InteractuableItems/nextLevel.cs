using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    [SerializeField] InfoNivel infoNivel;
    [SerializeField] Color fadeColor = Color.black;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            Initiate.Fade(infoNivel.name, fadeColor, 1f);
        }
    }
}
