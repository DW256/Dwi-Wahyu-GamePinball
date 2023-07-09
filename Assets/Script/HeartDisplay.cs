using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Image[] imageArray; // Array Image UI
    public int index; // Parameter index

    [SerializeField] private ScoringController scoring;

    private void Awake()
    {
        for (int i = 0; i < imageArray.Length; i++)
        {
            imageArray[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        index = scoring.currentLives;
        
    }

    private void FixedUpdate()
    {
        DisplayLifeImages(index);
    }

    public void DisplayLifeImages(int currentLife)
    {
        for (int i = 0; i < imageArray.Length; i++)
        {

            if (i <= currentLife)
            {
                imageArray[i].gameObject.SetActive(true); // Aktifkan gambar nyawa
            }
            else
            {
                imageArray[i].gameObject.SetActive(false); // Nonaktifkan gambar nyawa
            }
        }
    }
}
