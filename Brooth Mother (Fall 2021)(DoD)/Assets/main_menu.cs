using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    //initialize audio (source is from main camera)
    public AudioSource audio;
    private void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    //define function to play sound when button is clicked
    public void audioTrigger()
    {
        audio.Play();
    }

    //load level scene
    public void PlayGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(1);
    }

    //quit
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
