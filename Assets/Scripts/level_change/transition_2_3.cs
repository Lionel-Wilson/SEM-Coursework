using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition_2_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {






    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Level_3");
    }
}
