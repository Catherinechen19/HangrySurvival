using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    private static Audio instance;
    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } 
        else 
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }

        
    }
}
