using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScript : MonoBehaviour
{
    public TextMeshProUGUI Scoretext;
    float score;

    void Start()
    {
        score = PlayerPrefs.GetFloat("Score");
        Scoretext.text = "Ваше время: " + score.ToString("F2");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
