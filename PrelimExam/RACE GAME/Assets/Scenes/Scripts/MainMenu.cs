using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loading Game Scene when clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    //Closing the Application when (Only works when game is rendered or built)
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
