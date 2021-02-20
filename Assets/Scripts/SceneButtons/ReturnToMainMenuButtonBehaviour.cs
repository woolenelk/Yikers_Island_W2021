using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuButtonBehaviour : MonoBehaviour
{
    public void OnReturnButtonPressed()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
