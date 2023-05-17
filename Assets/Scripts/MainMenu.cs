using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    public void PlayGame ()
    {
        SceneManager.LoadScene("Shane");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Menu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Credits ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Control ()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Boss ()
    {
        SceneManager.LoadScene("Boss");
    }

    

    


}
