using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public void replayScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameLevel");
    }
}
