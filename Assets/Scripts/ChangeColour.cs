using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public GameObject batteryLight;
    Light lt;
    public float intensity = 5.0f;


    private void OnEnable()
    {
        EventManager.batteryYellow += ChangeYellow;
        EventManager.batteryRed += ChangeRed;
        EventManager.batteryFlashing += Flashing;
    }

    private void OnDisable()
    {
        EventManager.batteryYellow -= ChangeYellow;
        EventManager.batteryRed -= ChangeRed;
        EventManager.batteryFlashing -= Flashing;
    }

    void Start()
    {
        lt = batteryLight.GetComponent<Light>();
    }

    
    void ChangeYellow()
    {
        lt.color = Color.yellow;
    }

    void ChangeRed()
    {
        lt.color = Color.red;
    }

    void Flashing()
    {
        //TODO
    }
}
