using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public CharacterInput charIn;

    public Renderer renderer;

    public GameObject textObject;
    public TextMeshPro textbox;

    public bool colliding;
    public bool isVisible;

    // Start is called before the first frame update
    public void Start()
    {
        charIn = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInput>();

        textObject = Camera.main.transform.Find("TextBox").gameObject;
        textbox = textObject.GetComponent<TextMeshPro>();

        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliding = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliding = false;
        }
    }
}
