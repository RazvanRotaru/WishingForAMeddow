using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveBackLife : Interact
{
    private Inventory inventory;

    public GameObject errorTextObj;
    public PrintError errorFunction;

    public Mesh swapMesh;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        errorTextObj = Camera.main.transform.Find("ErrorBox").gameObject;
        errorFunction = errorTextObj.GetComponent<PrintError>();

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        swapMesh = GetComponent<MeshCollider>().sharedMesh;

    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            if (colliding)
            {
                textbox.text = "press   E   to give life";

                if (Input.GetKeyDown(charIn.interactKey))
                {
                    if (inventory.isFull && inventory.obj.CompareTag("Life"))
                    {
                        textbox.text = "";

                        GetComponent<MeshFilter>().mesh = swapMesh;
                        GetComponent<AudioSource>().Stop();

                        Destroy(inventory.obj);
                        inventory.isFull = false;

                        enabled = false;
                    }
                    else
                        errorFunction.text = "You can't to that";
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
