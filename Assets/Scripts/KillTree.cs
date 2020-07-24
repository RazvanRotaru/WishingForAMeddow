using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillTree : Interact
{
    
    public Mesh swapMesh;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        swapMesh = GameObject.Find("WillowDead").GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            if (colliding)
            {
                textbox.text = "press   E   to interact";

                if (Input.GetKeyDown(charIn.interactKey))
                {
                    textbox.text = "";

                    GetComponent<MeshFilter>().mesh = swapMesh;
                    GetComponent<AudioSource>().Play();
                }
                if (Input.GetKeyUp(charIn.interactKey))
                {
                    GetComponent<GiveBackLife>().enabled = true;
                    enabled = false;
                }
            }
            else
                textbox.text = "";
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
        textbox.text = "";
    }
}
