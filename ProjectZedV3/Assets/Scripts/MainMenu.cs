using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameSolo ()
    {
        SceneManager.LoadScene("MainLevel01");
    }

    public void PlayGameMulti()
    {
        SceneManager.LoadScene("LoginMenu");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
