using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ScoreListManager : MonoBehaviour
{
    public GameObject scoreTexts;
    private int[] Listedscores;
    private int[] savedScores;

    private int index;

    [SerializeField] private ScoringController scoring;

    public Transform prefabParent;

    public void AddListScore()
    {
        savedScores[index] = scoring.totalScore;
        index++;
    }


    void FixedUpdate()
    {

        // Assign data dari array int lainnya ke array scores
        Listedscores = new int[savedScores.Length];
        for (int i = 0; i < savedScores.Length; i++)
        {
            Listedscores[i] = savedScores[i];
        }

        SortAndDisplayScores();
    }

    void SortAndDisplayScores()
    {
        // Membuat instance prefab scoreItemPrefab sebagai item skor baru
        GameObject scoreItem = Instantiate(scoreTexts, prefabParent);

        // Mengatur nilai text pada item skor
        TextMeshProUGUI scoreText = scoreItem.GetComponent<TextMeshProUGUI>();
        scoreText.text = Listedscores.ToString();

        // Mengatur posisi dan ukuran item skor menggunakan RectTransform
        RectTransform rectTransform = scoreItem.GetComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
        rectTransform.localPosition = Vector3.zero;
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
}
