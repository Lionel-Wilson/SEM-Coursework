using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //To spin the coin
        transform.Rotate(0f, 180f * Time.deltaTime, 0f, Space.Self);
    }
}
