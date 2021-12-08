using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Animator animator;
    [SerializeField]private float moveSpeed = 20f;
    Vector2 movement;

    public GameObject GameOverText, RestartButton;
    public GameObject WinCanvas;


    [SerializeField] private GameObject bloodSplash; // #1
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioSource audioPlayer_Die;
    [SerializeField] private AudioSource audioBackground;
    [SerializeField] private AudioClip clipBackground;
    [SerializeField] private AudioClip clipWalk;
    [SerializeField] private AudioClip clipDie;
    FruitPicker fruitScore;
    [SerializeField] TextMeshProUGUI txtScore;

    private void Awake() {
        animator = GetComponent <Animator>();
        rb = GetComponent <Rigidbody2D>();
        fruitScore = GetComponent<FruitPicker>();
    }

    private void Start() {
        GameOverText.SetActive (false);
        RestartButton.SetActive(false);
        WinCanvas.SetActive(false);

        //Scoring
        txtScore.text = PlayerPrefs.GetInt("Score", 0).ToString();

        //Backgroud Sound
        audioBackground.PlayOneShot(clipBackground);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow key was pressed.");
            PlaySound();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was pressed.");
            PlaySound();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow key was pressed.");
            PlaySound();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right Arrow key was pressed.");
            PlaySound();
        }

        if (!Input.anyKey)
        {
            audioPlayer.Stop();
        }
        //INPUT
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            audioPlayer_Die.PlayOneShot(clipDie);
            gameObject.SetActive(false);
            InstantiateBloodSplash();
            audioPlayer.Stop();

            if (fruitScore.fruitScore > PlayerPrefs.GetInt("Score", 0))
            {
                PlayerPrefs.SetInt("Score", fruitScore.fruitScore);
                txtScore.text = fruitScore.ToString();
            }

        }
    }

    void InstantiateBloodSplash()
    {
        GameObject gb = Instantiate(bloodSplash);
        gb.transform.position = gameObject.transform.position;
        //gb.transform.localScale = new Vector2(5, 5);
    }

    void PlaySound()
    {
        audioPlayer.PlayOneShot(clipWalk);   
    }

}
