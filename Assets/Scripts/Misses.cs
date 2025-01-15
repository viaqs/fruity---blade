using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misses : MonoBehaviour
{
    public Sprite missedX;
    public Sprite Full;
    public List<Image> misses;


    private int lives;

    void Start()
    { 
        lives = misses.Count;
        Restart();
    }
    public void LoseLife()
    {
        if (lives > 0)
        {
           
            lives--;
            misses[lives].sprite = missedX;

          
            if (lives <= 0)
            {
                FindObjectOfType<UiManager>().EndGame();
            }
        }
    }

    public void Restart()
    {
        lives = misses.Count;
        foreach (var miss in misses)
        {
            miss.sprite = Full;
        }

    }







}
