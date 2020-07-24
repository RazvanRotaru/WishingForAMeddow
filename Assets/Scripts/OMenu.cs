using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OMenu : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.UnloadScene("OptionsScene");
    }

    public void Back()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
