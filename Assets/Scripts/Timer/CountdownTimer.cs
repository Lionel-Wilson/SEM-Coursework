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
        //Access the player Game Object
        player = GameObject.Find("Toon Chick").GetComponent<Player>();
        //set current time to starting time
        currentTime = startingTime;

        //If we are in Level 3, increase starting time to 25 seconds
        if(SceneManager.GetActiveScene().name == "Level_3")
        {
            startingTime = 25f;
            currentTime = startingTime;
        }
        countdownText.color = Color.green;
        
    }

    //Return the starting Time (Used in Scoring)
    public float returnTime()
    {
        return startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Continuously decrease the time
        currentTime -= 1 * Time.deltaTime;
        //To display the time using the UI
        countdownText.text = currentTime.ToString("0");

        //If the player collected a coin, add 5 seconds
        if (player.getCoinCollected() || player.getCheckpointPassed())
        {
            currentTime += 5f;
        }

        //If the player failed a jump, subtract 5 seconds
        if (player.getFailedLanding())
        {
            currentTime -= 5f;
        }

        //If the time remaining is more than or equal to 70% of the starting time then use Green colour to display time
        if (currentTime >= 0.7 * startingTime)
        {
            countdownText.color = Color.green;
                //Decrease Font Size
                decreaseFontSize();
        }

        //If the time remaining is less than or equal to 70% of the starting time and more than or equal to
        //30% of the starting time remaing, then use Yellow colour to display time
        if (currentTime <= 0.7 * startingTime && currentTime >= 0.3 * startingTime)
        {
            countdownText.color = Color.yellow;

                //Decrease Font Size
                decreaseFontSize();
        }

        //If the time remaining is less than or equal to 30% of the starting time then use Red colour to display time
        if (currentTime <= 0.3 * startingTime)
        {
            countdownText.color = Color.red;

            //Make the font size bigger
            if(!danger)
            {
                danger = true;
                //Increase Font Size
                increaseFontSize();
            }
        }

        //If the current time is less than 0, then set the time to 0.
        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("End_menu");
        }
        
    }

    //Increases the font size by 30
    private int increaseFontSize()
    {
        return countdownText.fontSize += 30;
    }

    //Decrease the font size
    private int decreaseFontSize()
    {
        //Checks if danger was true (i.e. collected coin and went from Green to Yellow colour text)
        if(danger)
        {
            danger = false;
            //Decrease font size
            return countdownText.fontSize -= 30;
        } else
        {   
            //Else Do Nothing
            return countdownText.fontSize;
        }
    }
}
