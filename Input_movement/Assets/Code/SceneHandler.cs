using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void OnApplicationQuit()
    {
        Application.Quit();

    }
}
