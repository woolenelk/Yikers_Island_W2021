using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButtonBehaviour : MonoBehaviour
{

    public void OnInstructionsButtonPressed()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Instructions");
    }
}
