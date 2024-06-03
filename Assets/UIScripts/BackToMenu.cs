using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] InfoNivel infoNivel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Initiate.Fade(infoNivel.name, Color.black, 1.0f);
    }
}
