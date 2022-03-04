using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentTime = 0f;
    private float startingTime = 10f;
    private bool danger = false;
    private Player player;

    [SerializeField] Text countdownText;
    void Start()
    {
        player = GameObject.Find("Toon Chick").GetComponent<Player>();
        currentTime = startingTime;
        if(SceneManager.GetActiveScene().name == "Level_3" || SceneManager.GetActiveScene().name == "Level_4")
        {
            startingTime = 25f;
            currentTime = startingTime;
        }
        countdownText.color = Color.green;
        
    }

    public float returnTime()
    {
        return startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (player.getCoinCollected())
        {
            currentTime += 5f;
        }

        if (player.getFailedLanding())
        {
            currentTime -= 5f;
        }

        if (currentTime >= 0.7 * startingTime)
        {
            countdownText.color = Color.green;
                decreaseFontSize();
        }

        if (currentTime <= 0.7 * startingTime && currentTime >= 0.3 * startingTime)
        {
            countdownText.color = Color.yellow;

                decreaseFontSize();
        }

        if (currentTime <= 0.3 * startingTime)
        {
            countdownText.color = Color.red;
            if(!danger)
            {
                danger = true;
                increaseFontSize();
            }
        }


        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        
    }

    private int increaseFontSize()
    {
        return countdownText.fontSize += 30;
    }

    private int decreaseFontSize()
    {
        if(danger)
        {
            danger = false;
            return countdownText.fontSize -= 30;
        } else
        {
            return countdownText.fontSize;
        }
    }
}
