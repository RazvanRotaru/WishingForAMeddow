using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Consume : Interact
{
    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            if (colliding)
            {
                textbox.text = "press   E   to consume";

                if (Input.GetKeyDown(charIn.interactKey))
                {
                    textbox.text = "";
                    if (CompareTag("PowerUp"))
                    {
                        EventManager.CallGainPower();
                    }
                    if (CompareTag("StartGPS"))
                    {
                        EventManager.CallEnableGPS();
                    }
                    Destroy(this.gameObject);
                }
            }
            else
                textbox.text = "";
        }
    }
}
