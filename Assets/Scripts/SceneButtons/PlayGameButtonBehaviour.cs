using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButtonBehaviour : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("YikersIsland");
    }
}
