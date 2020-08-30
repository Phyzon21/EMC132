using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Loading the Scene Menu when its clicked
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    //Loading Game Scene when its clicked
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
