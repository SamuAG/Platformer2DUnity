using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotonNivel : MonoBehaviour
{
    [SerializeField] TMP_Text nombreNivel;
    [SerializeField] Image imagenNivel;

    [SerializeField] InfoNivel infoNivel;

    public InfoNivel InfoNivel { get => infoNivel; set => infoNivel = value; }

    [SerializeField] AudioSource audioSource;

    void Start()
    {
        nombreNivel.text = infoNivel.nombreNivel;
        imagenNivel.sprite = infoNivel.imagenNivel;
    }

    public void CambiarNivel()
    {
        audioSource.Play();
        Initiate.Fade(infoNivel.name, Color.black, 1.0f);

    }
}
