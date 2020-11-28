using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameLeft()
    {
        SceneManager.LoadScene("LeftLevel1");
    }

    public void PlayGameLeftLevel2()
    {
        SceneManager.LoadScene("LeftLevel2");
    }

    public void PlayGameRight()
    {
        SceneManager.LoadScene("RightLevel1");
    }

    public void PlayGameRightLevel2()
    {
        SceneManager.LoadScene("RightLevel2");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
}
