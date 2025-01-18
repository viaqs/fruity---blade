using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BestText;
    public TextMeshProUGUI text;
    public TextMeshProUGUI bestScored;
    public TextMeshProUGUI Scored;
    public Image watermelon;
    public Image background;
    public Image FadingEffect;
    private int score;
    private int banTime = 10;

    public AudioSource AudioSource;
    public AudioClip bombSound;
    public AudioClip fruitSlicing;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void slicingSounds()
    {
        AudioSource.PlayOneShot(fruitSlicing);
    }
    public void ZenMode()
    {
        SceneManager.LoadScene("Zen");
    }

    public void ClassicMode()
    {
        SceneManager.LoadScene("Classic");
    }

    public void NewGame()
    {
        
        Timer.remainingTime = 120;
        ScoreText.gameObject.SetActive(true);
        BestText.gameObject.SetActive(true);
        
        score = 0;
        ScoreText.text = score.ToString();
        background.gameObject.SetActive(false);
        watermelon.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        FindObjectOfType<Spawner>().OnEnable();
        FindObjectOfType<Blade>().OnEnable();

    }
    public void IncreaseScore(int amount)
    {   
        score+=amount;
        ScoreText.text = score.ToString("D2");
        float highscore = PlayerPrefs.GetFloat("highscore", 0);

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
            BestText.text = highscore.ToString();
            bestScored.text = highscore.ToString();
        }
    }

    public void Explosion()
    {
        Timer.remainingTime -= banTime;
        StartCoroutine(ExplodingAnim());
        AudioSource.PlayOneShot(bombSound);
    }

    public void EndGame()
    {
        FindObjectOfType<Spawner>().OnDisable();
        FindObjectOfType<Blade>().OnDisable();
        text.gameObject.SetActive (false);
        background.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        BestText.gameObject.SetActive(false);
        watermelon.gameObject.SetActive(false); 
        Scored.text = ScoreText.text;
        bestScored.text = BestText.text;

    }

    public void OnButtonClick()
    {
        NewGame();
        FindObjectOfType<Misses>().Restart();
    }

    public void returnToMain()
    {
        SceneManager.LoadScene("Main Page");     
    }

    private IEnumerator ExplodingAnim()
    {
        float elapsed = 0f;
        float duration = 0.5f;
       
        while (elapsed < duration)
        {
            
            float time = Mathf.Clamp01(elapsed/duration);
            FadingEffect.color = Color.Lerp(Color.clear, Color.white, time);
            watermelon.color = Color.Lerp(Color.white,Color.clear, time);
            Time.timeScale = 1f - time;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        elapsed = 0f;

        while (elapsed < duration)
        {
            float time = Mathf.Clamp01(elapsed / duration);
            FadingEffect.color = Color.Lerp(Color.white, Color.clear, time);
            watermelon.color = Color.Lerp(Color.clear, Color.white, time);
            
            elapsed += Time.unscaledDeltaTime;
            yield return null;
            
        }
       
    }

  
}   
