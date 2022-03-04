using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    private float startingScore = 100f;
    private float currentScore = 0f;
    private float ratio;
    private CountdownTimer countdownTimer;

    [SerializeField] Text scoreText;
    void Start()
    {
        countdownTimer = GameObject.Find("Canvas/Timer").GetComponent<CountdownTimer>();
        currentScore = startingScore;
        ratio = startingScore / countdownTimer.returnTime();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScore -= ratio * Time.deltaTime;
        scoreText.text = "Score: " + currentScore.ToString("0");

        if(currentScore <= 0)
        {
            currentScore = 0;
        }


    }
}
