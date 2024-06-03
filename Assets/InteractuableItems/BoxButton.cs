using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite activeSprite;
    [SerializeField] Sprite inactiveSprite;
    [SerializeField] private GameObject targetObject;
    [SerializeField] bool reverse = false;
    AudioSource audioSource;

    private void Start()
    {
        targetObject.SetActive(reverse);
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter" + collision.name);
        if (collision.CompareTag("Player") || collision.CompareTag("Box") || collision.CompareTag("Enemy"))
        {
            if (audioSource != null) audioSource.Play();
            if (reverse)
            {
                if (targetObject == null) return;
                targetObject.SetActive(false);
                sr.sprite = activeSprite;
            }
            else
            {
                if (targetObject == null) return;
                targetObject.SetActive(true);
                sr.sprite = activeSprite;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box") || collision.CompareTag("Enemy"))
        {
            if (audioSource != null) audioSource.Play();
            if (reverse)
            {
                if (targetObject == null) return;
                targetObject.SetActive(true);
                sr.sprite = inactiveSprite;
            }
            else
            {
                if (targetObject == null) return;
                targetObject.SetActive(false);
                sr.sprite = inactiveSprite;
            } 
        }
    }
}
