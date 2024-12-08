using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstScene_name;
    public string creditPageScene_name;
    public void StartGame()
    {
        SceneManager.LoadScene(firstScene_name);
    }

    public void OpenCredit()
    {
        SceneManager.LoadScene(creditPageScene_name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
