using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back2Menu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
