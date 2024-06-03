using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            Collider2D col = Physics2D.OverlapCircle(transform.position, radius);
            
            if (col.TryGetComponent<PlayerController>(out PlayerController player))
            {
                Debug.Log("Player found");
                if (TryGetComponent<IInteractuable>(out IInteractuable interactuable))
                {
                    Debug.Log("Interactuable found");
                    if (audioSource != null) audioSource.Play();
                    interactuable.Interact();
                }
            }
        }
    }
}
