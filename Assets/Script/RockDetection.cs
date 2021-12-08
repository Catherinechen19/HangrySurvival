using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
         if(other.transform.tag == "rock")
        {
            Debug.Log("Rock Detected!");
        }
        
    }
}
