using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractuable : MonoBehaviour, IInteractuable
{
    [SerializeField] GameObject reward;
    [SerializeField] Vector2 offset = new Vector2(0,1);
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openChest;
    bool isOpen = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            spriteRenderer.sprite = openChest;
            Instantiate(reward, (Vector2)transform.position + offset, Quaternion.identity);
        }
    }
}
