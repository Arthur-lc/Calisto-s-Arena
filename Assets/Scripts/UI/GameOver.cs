using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void StartAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        Time.timeScale = 2;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit() {
        Application.Quit();
    }
}
