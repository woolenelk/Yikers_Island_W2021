using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonbehaviour : MonoBehaviour
{
    public void OnGameOverButtonPressed()
    {
        SceneManager.LoadScene("GameOver");
    }
}
