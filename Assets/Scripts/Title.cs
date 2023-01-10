using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
