using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    public float score;
    public TextMeshProUGUI timeScore;
    public int sec1, sec2;

    public bool isGameover;

    public GameObject GameOver;
    public GameObject YouWin;
    public TextMeshProUGUI YourTime;

    Rigidbody rb;

    private void Awake()
    {
        isGameover = false;
        score = 0;
        
        PlayerPrefs.SetFloat("Score", score);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGameover == false)
        {
            score += Time.deltaTime;
            timeScore.text = "Время: " + score.ToString("F2");
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h * speed, rb.velocity.y, v * speed));

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DeathZone") 
        {
            isGameover = true;
            GameOver.SetActive(true);
        }

        if (other.tag == "Finish")
        {
            isGameover = true;
            YouWin.SetActive(true);
            YourTime.text = "Ваше время: " + score.ToString("F2");
            PlayerPrefs.SetFloat("Score", score);
        }
    }
}
