using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowtoPlay : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Intro1");
    }

    public void Back()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void RulesPlay()
    {
        SceneManager.LoadScene("GameLevel");
    }


    public void RulesBack()
    {
        SceneManager.LoadScene("Setting");
    }
    
    public void Settings()
    {
        SceneManager.LoadScene("Rules");
    }

    public void credits()
    {
        SceneManager.LoadScene("Credit");
    }

    public void credits2()
    {
        SceneManager.LoadScene("Credit2");
    }

    public void exitcredit()
    {
        SceneManager.LoadScene("Setting");
    }
}
