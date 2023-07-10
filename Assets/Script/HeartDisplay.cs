using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private ScoringController scoring;

    public Image[] imageArray; // Array Image UI untuk gambar
    public int startIndex; // Indeks mulai untuk menampilkan gambar
    public int displayCount; // Jumlah gambar yang akan ditampilkan

    private int endIndex;

    public void Update()
    {

        endIndex = scoring.currentLives;

        for (int i = 0; i < imageArray.Length; i++)
        {
            if (i >= startIndex && i <= endIndex)
            {
                imageArray[i].gameObject.SetActive(true); // Aktifkan gambar
            }
            else
            {
                imageArray[i].gameObject.SetActive(false); // Nonaktifkan gambar
            }
        }
    }
}
