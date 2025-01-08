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
    public TextMeshProUGUI bestScored;
    public TextMeshProUGUI Scored;
    public Image background;
    private int score;
    private int banTime = 10;

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

    private void Start()
    {
        NewGame();
        

    }
    public void NewGame()
    {
        Timer.remainingTime = 120;
        ScoreText.gameObject.SetActive(true);
        BestText.gameObject.SetActive(true);

        score = 0;
        ScoreText.text = score.ToString();
        background.gameObject.SetActive(false);
        FindObjectOfType<Spawner>().OnEnable();
        FindObjectOfType<Blade>().OnEnable();

    }
    public void IncreaseScore(int amount)
    {   
        score+=amount;
        ScoreText.text = score.ToString("D2");
    }

    public void Explosion()
    {
        Timer.remainingTime -= banTime;
    }

    public void EndGame()
    {
        FindObjectOfType<Spawner>().OnDisable();
        FindObjectOfType<Blade>().OnDisable();
        background.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        BestText.gameObject.SetActive(false);
        Scored.text = ScoreText.text;
        bestScored.text = BestText.text;

    }

    public void OnButtonClick()
    {
        NewGame();
    }




}
