using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtonbehaviour : MonoBehaviour
{
    public void OnCreditsButtonPressed()
    {
        SceneManager.LoadScene("Credits");
    }
}
