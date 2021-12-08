using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitPicker : MonoBehaviour
{
    public int fruitScore=0;
    public GameObject WinCanvas;

    //public Text ScoreText;

    [SerializeField] private AudioSource audioFruit;
    [SerializeField] private AudioClip clipFruit;
    private void OnTriggerEnter2D(Collider2D fruit)
    {
        if(fruit.transform.tag == "fruit")
        {
            Destroy(fruit.gameObject);
            fruitScore += 1;
            audioFruit.PlayOneShot(clipFruit);

            if(fruitScore == 463)
            {
                WinCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    private void Start() {
       // fruitScore = 0;
        //ScoreText.Text = "Score: " + fruitScore.ToString();
    }
}
