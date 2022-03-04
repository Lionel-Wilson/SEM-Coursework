using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        countdownTimer = GameObject.Find("Canvas/Timer").GetComponent<CountdownTimer>();
        player = GameObject.Find("Toon Chick").GetComponent<Player>();
        currentScore = startingScore;
        ratio = startingScore / countdownTimer.returnTime();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getCoinCollected())
        {
            currentScore += 5f;
            player.setCoinCollected();
        }

        currentScore -= ratio * Time.deltaTime;


        if(currentScore <= 0)
        {
            currentScore = 0;
        }

        scoreText.text = "Score: " + currentScore.ToString("0");
    }

    public float addScore(float scoreToAdd)
    {
        return currentScore + scoreToAdd;
    }

}
