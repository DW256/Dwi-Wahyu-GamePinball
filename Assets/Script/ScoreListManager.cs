using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ScoreListManager : MonoBehaviour
{
    public static ScoreListManager instance;

    public GameObject scoreTexts;
    public List<int> savedScores;

    private void Awake()
    {
        if (instance == null)
        {
            savedScores = new List<int>();
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddListScore(int totalScore)
    {
        savedScores.Add(totalScore);
    }

}
