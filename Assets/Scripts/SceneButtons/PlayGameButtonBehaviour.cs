using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButtonBehaviour : MonoBehaviour
{
    public AudioSource buttonSound;
    public void OnPlayButtonPressed()
    {
        //SceneManager.LoadScene("YikersIsland");
        buttonSound.Play();
        SceneManager.LoadScene("NavMesh Test");

    }
}
