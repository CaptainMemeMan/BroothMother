using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class PauseManger : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioSource resume;

    public GameObject pausemenuUi;

    //private void Awake()
    //{
    //    goldreset = GetComponent<Currency>();
    //}
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
       
        GameIsPaused = false;
        pausemenuUi.SetActive(false);
        Time.timeScale = 1f;

        Debug.Log("resume");
    }
    public void Pause()
    {
        GameIsPaused = true;
        Debug.Log("Pause");
        pausemenuUi.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
