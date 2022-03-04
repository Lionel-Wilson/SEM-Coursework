using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField] private Material start;
    [SerializeField] private Material activated;

 


    private void OnTriggerEnter(Collider other)
    {
        //Changes colour of the checkpoint flag
        GameObject Flag = transform.GetChild(2).gameObject;
        Flag.GetComponent<Renderer>().material = activated;
           
    }
}
