using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fuir : MonoBehaviour
{
    public void QuittheGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
