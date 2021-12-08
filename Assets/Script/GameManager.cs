using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioOpening;
    [SerializeField] private AudioClip clipOpening;
    private void Start() 
    {
        audioOpening.PlayOneShot(clipOpening);
    }

    
}
