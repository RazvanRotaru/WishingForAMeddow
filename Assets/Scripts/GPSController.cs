using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GPSController : MonoBehaviour
{
    
    public TextMeshPro gpsbox;
    public GameObject player;
    public bool gpsON;

    // Start is called before the first frame update
    void Start()
    {
        gpsbox = transform.Find("GPS").gameObject.GetComponent<TextMeshPro>();
        player =  GameObject.FindGameObjectWithTag("Player");
        EventManager.enableGPS += GPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (gpsON)
        {
            gpsbox.text = String.Format("X: {0:0.00}   Y: {1:0.00}", player.transform.localPosition.x, player.transform.localPosition.z);
            
        }
    }
    void GPS()
    {
        gpsON = true;
    }
}
