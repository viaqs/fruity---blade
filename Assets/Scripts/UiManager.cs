using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BestText;
    private int score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void NewGame()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }
    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score.ToString("D2");
    }

    
}
