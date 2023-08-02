using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject menuPause;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        menuPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        menuPause.SetActive(false);     
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;    
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
