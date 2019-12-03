using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    public GameObject player; //Player gameobject
    public GameObject slider; //Slider Gameobject
    public Slider health; //Slider reference

    void Update()
    {
        //Look at players location
        transform.LookAt(player.transform);
        //If player is within the distance between the healthbar location and within range
        if (Vector3.Distance(player.transform.position, this.transform.position) < 20)
        {
            //Set slider to visable
            slider.SetActive(true);
        }
        else
        {
            //Set slider to hidden
            slider.SetActive(false);
        }
    }
}
