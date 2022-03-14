using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition_menu : MonoBehaviour
{
    private Scoring score;
    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Level_1/Canvas/Score").GetComponent<Scoring>();
        scoreText.text = "Score: " + score.getScore();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
