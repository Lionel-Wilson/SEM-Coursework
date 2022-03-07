using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    //reference - https://www.youtube.com/watch?v=9dYDBomQpBQ
    public GameObject pausepanel;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pausepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}