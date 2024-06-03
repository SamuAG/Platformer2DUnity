using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayerOnTouch : MonoBehaviour
{
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
            collision.gameObject.SetActive(false);
            Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1);
        }
    }
}
