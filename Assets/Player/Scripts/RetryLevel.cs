using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1f);
        }
            
    }
}
