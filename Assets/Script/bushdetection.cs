using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushdetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
         if(other.transform.tag == "bushes")
        {
            Debug.Log("Bushes Detected!");
        }
        
    }
}
