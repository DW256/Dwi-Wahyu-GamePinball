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
    private List<int> savedScores;

    private int index = 0;

    public ScoringController scoring;
    public Transform prefabParent;


    private void Awake()
    {
        savedScores = new List<int>();
    }
    public void AddListScore()
    {
        if (scoring == null) return;
        savedScores.Add(scoring.totalScore);
        ListingScores();

        //if(scoring != null)
        //{
        //    for (int i = 0; i < savedScores.Count; i++)
        //    {
        //        if (i == index)
        //        {
        //            savedScores[index] = scoring.GetComponent<ScoringController>().totalScore;
        //            index++;
        //            ListingScores();
        //        }
        //    }
        //}
    }


    private void ListingScores()
    {
        int index= 0;

        // Membuat instance prefab scoreItemPrefab sebagai item skor baru
        GameObject scoreItem = Instantiate(scoreTexts, prefabParent);

        // Assign data dari array int lainnya ke array scores
        Listedscores = new int[savedScores.Count];

        // Mengatur nilai text pada item skor
        TextMeshProUGUI scoreText = scoreItem.GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < savedScores.Count; i++)
        {
            if(i == index)
            {
                Listedscores[index] = savedScores[index];
                scoreText.SetText(Listedscores[index].ToString());
                index++;
            }
            
        }


        // Mengatur posisi dan ukuran item skor menggunakan RectTransform
        RectTransform rectTransform = scoreItem.GetComponent<RectTransform>();

        rectTransform.localScale = Vector3.one;
        rectTransform.localPosition = Vector3.zero;
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }

}
