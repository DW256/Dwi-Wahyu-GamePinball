using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreListRenderer : MonoBehaviour
{
    public static ScoreListManager instance;

    public GameObject scoreTexts;
    //private int[] Listedscores;

    public Transform prefabParent;

    public void ListingScores()
    {
        int index = 0;
        List<int> savedScores = ScoreListManager.instance.savedScores;

        foreach (int score in savedScores)
        {
            GameObject scoreItem = Instantiate(scoreTexts, prefabParent);
            TextMeshProUGUI scoreText = scoreItem.GetComponent<TextMeshProUGUI>();
            scoreText.SetText(score.ToString());
        }


        //// Membuat instance prefab scoreItemPrefab sebagai item skor baru
        //GameObject scoreItem = Instantiate(scoreTexts, prefabParent);

        //// Assign data dari array int lainnya ke array scores
        //Listedscores = new int[savedScores.Count];

        //// Mengatur nilai text pada item skor
        //TextMeshProUGUI scoreText = scoreItem.GetComponent<TextMeshProUGUI>();

        //for (int i = 0; i < savedScores.Count; i++)
        //{
        //    if (i == index)
        //    {
        //        Listedscores[index] = savedScores[index];
        //        scoreText.SetText(Listedscores[index].ToString());
        //        index++;
        //    }

        //}


        //// Mengatur posisi dan ukuran item skor menggunakan RectTransform
        //RectTransform rectTransform = scoreItem.GetComponent<RectTransform>();

        //rectTransform.localScale = Vector3.one;
        //rectTransform.localPosition = Vector3.zero;
        //rectTransform.anchorMin = new Vector2(0.5f, 1f);
        //rectTransform.anchorMax = new Vector2(0.5f, 1f);
        //rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
}
