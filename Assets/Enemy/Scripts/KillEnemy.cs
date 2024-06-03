using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] GameObject root;
    [SerializeField] float impulseForce = 20;
    [SerializeField] AudioSource audioPrefab;
    [SerializeField] AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy killed");
            // TODO: Spawn a particle effect and play a sound
            if (audioPrefab != null)
            {
                AudioSource temp = Instantiate(audioPrefab, transform.position, Quaternion.identity);
                temp.clip = audioClip;
                temp.Play();
            }
            // impulso hacia arriba
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
            Destroy(root);
        }
    }
}
