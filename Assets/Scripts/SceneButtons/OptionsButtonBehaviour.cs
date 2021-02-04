using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButtonBehaviour : MonoBehaviour
{
    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }
}
