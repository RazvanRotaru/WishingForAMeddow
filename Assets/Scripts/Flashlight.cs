using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    CharacterInput charIn;

   // public GameObject flashlight;
    public GameObject lightObject;
    public Inventory inventory;
    
    public float energy;

    private float lowEnergy = 60 * 30;
    private float veryLowEnergy = 60 * 10;

    [SerializeField]
    private int lightColour = 3;  // 3 - Blue, 2 - Yellow, 1 - Red

    private bool lightOn;

    private bool flashlightEnabled;



    // Start is called before the first frame update
    void Start()
    {
        lightObject = GetComponent<Transform>().Find("LightObject").gameObject;
        charIn = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInput>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        flashlightEnabled = false;
        lightObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (inventory.isFull && inventory.obj.CompareTag("Phone"))
        {
            if (Input.GetKeyDown(charIn.flashlightKey))
            {
                flashlightEnabled = !flashlightEnabled;
            }

            if (flashlightEnabled)
            {
                if (energy <= 0)
                {
                    if (lightOn)
                    {
                        lightObject.SetActive(false);
                        lightOn = false;
                    }
                }
                if (energy > 0)
                {
                    if (!lightOn)
                    {
                        lightObject.SetActive(true);
                        lightOn = true;
                    }
                    energy -= Time.deltaTime;

                    if (energy < lowEnergy && lightColour == 3)
                    {
                        EventManager.CallYellow();
                        lightColour -= 1;
                    }

                    if (energy < veryLowEnergy & lightColour == 2)
                    {
                        EventManager.CallRed();
                        lightColour -= 1;
                    }
                }
            }
            else
            {
                if (lightOn)
                {
                    lightObject.SetActive(false);
                    lightOn = false;
                }
            }
        }    
    }
}
