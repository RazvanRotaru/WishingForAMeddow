using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PickUp : Interact
{
    private Inventory inventory;
    private Rigidbody rigidBody;
    public Transform hand;

    public Vector3 PickPosition;
    public Vector3 PickRotation;

    public bool held;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        rigidBody = GetComponent<Rigidbody>();

        renderer.material.shader = Shader.Find("Mobile/Diffuse");
    }

    // Update is called once per frame
    void Update()
    {
        if (!inventory.isFull && isVisible)
        {
            check = true;
            if (colliding)
            {
                textbox.text = "press   E   to pick up";

                if (Input.GetKeyDown(charIn.interactKey))
                {
                    inventory.isFull = true;
                    inventory.obj = this.gameObject;
                    
                    transform.parent = hand;
                    renderer.material.shader = Shader.Find("Standard");

                    rigidBody.isKinematic = true;
                    rigidBody.detectCollisions = false;

                    transform.localPosition = PickPosition;
                    transform.localEulerAngles = PickRotation;

                    held = true;
                    textbox.text = "";
                }
            }
            else
                textbox.text = "";
        }
        else
            check = false;
    }
}
