using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuButtonBehaviour : MonoBehaviour
{
    public void OnReturnButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
