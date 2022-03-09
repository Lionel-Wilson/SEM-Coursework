using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    private float startingScore = 100f;
    private float currentScore = 0f;
    private float ratio = 0f;
    private CountdownTimer countdownTimer;
    private Player player;

    [SerializeField] Text scoreText;
    void Start()
    {
        //Access the timer and player Game Object
        countdownTimer = GameObject.Find("Canvas/Timer").GetComponent<CountdownTimer>();
        player = GameObject.Find("Toon Chick").GetComponent<Player>();

        //Set the current score the starting score
        currentScore = startingScore;

        //The ratio calculates how fast the score should decrease
        ratio = (startingScore / countdownTimer.returnTime()) / 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player has collected the coin, then add 5 to the score and setCoinCollected back to False
        if(player.getCoinCollected())
        {
            currentScore += 5f;
            player.setCoinCollected();
        }

        if(player.getCheckpointPassed())
        {
            currentScore += 5f;
            player.setCheckpointPassed();
        }

        //If the player fails to land a jump, then decrease 5 from the score and setFailedLanding back to False
        if(player.getFailedLanding())
        {
            currentScore -= 5f;
            player.setFailedLanding();
        }

        //A continuous substraction of the current score depending on the ratio
        currentScore -= ratio * Time.deltaTime;

        //If the score is less than 0, then reset it to 0.
        if(currentScore <= 0)
        {
            currentScore = 0;
            SceneManager.LoadScene("End_menu");
        }

        //To show the score using the UI
        scoreText.text = "Score: " + currentScore.ToString("0");
    }

}
