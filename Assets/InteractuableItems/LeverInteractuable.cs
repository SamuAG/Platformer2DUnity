using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteractuable : MonoBehaviour, IInteractuable
{
    [SerializeField] GameObject door;
    bool isActive = true;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = isActive;
    }
    
    public void Interact()
    {
        isActive = !isActive;
        spriteRenderer.flipX = isActive;
        door.SetActive(isActive);
    }
}
