using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject slider;
    public Slider health;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Vector3.Distance(player.transform.position, this.transform.position) < 20)
        {
            slider.SetActive(true);
        }
        else
        {
            slider.SetActive(false);
        }
    }
}
