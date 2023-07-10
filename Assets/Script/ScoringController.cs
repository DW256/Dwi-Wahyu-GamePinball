using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringController : MonoBehaviour
{
    public int maxLives = 3; // Jumlah nyawa maksimal
    public TextMeshProUGUI scoreText; // UI Text untuk menampilkan skor
    //public TextMeshProUGUI livesText; // UI Text untuk menampilkan nyawa
    public TextMeshProUGUI totalScoreText;
    public Transform hudPanel;
    public Transform gameOverPanel; //UI Game Over Panel


    public int[] scoreArray; // Array untuk mengakumulasi skor
    public int currentLives; // Nyawa saat ini
    public int currentScore; // Skor saat ini

    public int totalScore;
 

    private void Start()
    {
        currentLives = maxLives; // Set nyawa awal
        scoreArray = new int[maxLives]; // Inisialisasi array skor
       
        currentScore = 0; // Set skor awal

       
        //UpdateLivesText(); // Update tampilan nyawa
    }

    private void Update()
    {
        UpdateScoreText(); // Update tampilan skor
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString(); // Update teks skor
    }

    //private void UpdateLivesText()
    //{
    //    //livesText.text = "Lives: " + currentLives.ToString(); // Update teks nyawa
    //}

    public void AddScore(int points)
    {
        currentScore += points; // Menambahkan skor
        UpdateScoreText(); // Update tampilan skor
    }

    public void ReduceLives()
    {

        //Debug.Log("Live Reduced");
        currentLives--; // Mengurangi nyawa
        scoreArray[currentLives] = currentScore; //Mengurangi var currentLives terlebih dahulu supaya sekalian indexnya pas
        currentScore = 0;
        //UpdateLivesText(); // Update tampilan nyawa

        if (currentLives <= 0)
        {
            //CalculateTotalScore(); // Hitung total skor
            gameOver();
        }


    }

    private void CalculateTotalScore()
    {
       

        for (int i = 0; i < scoreArray.Length; i++)
        {
            totalScore += scoreArray[i];
        }

        Debug.Log("Total Score: " + totalScore);
    }

    private void gameOver()
    {
        CalculateTotalScore();
        totalScoreText.text = totalScore.ToString();
        hudPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f; //STop Time
    }
}
