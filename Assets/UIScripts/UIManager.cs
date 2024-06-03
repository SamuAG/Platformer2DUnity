using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] InfoNivel[] niveles;
    [SerializeField] GameObject prefabBotonNivel;
    [SerializeField] GameObject contenedorBotones;
    AudioSource audioSource;
    bool isFirstTime = true;

    private void Start()
    {
        contenedorBotones.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource = GetComponent<AudioSource>();
    }

    public void MostrarNiveles(){
        audioSource.Play();
        contenedorBotones.SetActive(!contenedorBotones.activeSelf);
    }

    public void CambiarNivel(InfoNivel nivel)
    {
        audioSource.Play();
        Initiate.Fade(nivel.nombreNivel, Color.black, 1.0f);
        
    }

    public void Salir()
    {
        audioSource.Play();
        Application.Quit();
    }
}
