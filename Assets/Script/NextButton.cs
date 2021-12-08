using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void NextScene1()
    {
        SceneManager.LoadScene("Intro2");
    }

    public void NextScene2()
    {
        SceneManager.LoadScene("Intro3");
    }

    public void NextScene3()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
