using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonBehaviour : MonoBehaviour
{
    public GameObject PauseCanvas;
    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0.0f;
        PauseCanvas.SetActive(true);
    }
}
