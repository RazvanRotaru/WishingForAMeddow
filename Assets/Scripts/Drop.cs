using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    private Inventory inventory;
    private CharacterInput charIn;
    private CharacterController charCtrl;

    private Renderer renderer;

    public GameObject textObject;
    public TextMeshPro textbox;

    public GameObject level;

    private float holdTime = 0.5f;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        charIn = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInput>();
        charCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        textObject = Camera.main.transform.Find("TextBox").gameObject;
        textbox = textObject.GetComponent<TextMeshPro>();

        renderer = GetComponent<Renderer>();
        renderer.material.shader = Shader.Find("Mobile/Diffuse");
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.isFull && GameObject.ReferenceEquals(this.gameObject, inventory.obj))
        {
            if (Input.GetKey(charIn.interactKey))
            {
                if (startTime == 0.0f)
                {
                    startTime = Time.time;
                }

                if (startTime + holdTime <= Time.time)
                {
                    inventory.isFull = false;

                    level = GameObject.FindGameObjectWithTag("Level");

                    transform.parent = level.transform;
                    inventory.obj = null;

                    renderer.material.shader = Shader.Find("Mobile/Diffuse");

                    Rigidbody rigidBody = GetComponent<Rigidbody>();
                    rigidBody.isKinematic = false;
                    rigidBody.detectCollisions = true;

                    if (charCtrl.kinecticPower)
                    {
                        rigidBody.constraints = RigidbodyConstraints.FreezePosition;
                    }

                    startTime = 0.0f;
                }
            }
            if (Input.GetKeyUp(charIn.interactKey))
            {
                startTime = 0.0f;
            }
        }
    }
}
