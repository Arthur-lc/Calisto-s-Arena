using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Animation um;
    public Animation dois;

    private void Start() {
        um.Play();
        dois.Play();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            um.Play();
            dois.Play();
        }
    }

    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit() {
        Application.Quit();
    }
}
