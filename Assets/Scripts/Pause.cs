using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseUi;
    public GameObject pauseButton;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void pause()
    {
        pauseUi.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        //sound.Stop();
        AudioListener.pause = true;
    }

    public void resume()
    {
        pauseUi.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        //sound.Play();
        AudioListener.pause = false;
    }

    public void Quit()
    {
        Application.Quit();
       
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
