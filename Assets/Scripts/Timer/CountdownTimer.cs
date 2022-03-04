using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if (currentTime <= 0.7 * startingTime)
        {
            countdownText.color = Color.yellow;
        }

        if (currentTime <= 0.3 * startingTime)
        {
            countdownText.color = Color.red;
            if(!danger)
            {
                countdownText.fontSize = countdownText.fontSize + 30;
                danger = true;
            }
        }


        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        
    }
}
