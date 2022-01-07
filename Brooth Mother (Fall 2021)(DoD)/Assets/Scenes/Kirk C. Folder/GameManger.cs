using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;
using UnityEngine.UI; 

public class GameManger : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }
    public void StopGame()
    {
        Application.Quit(); 
    }
}
