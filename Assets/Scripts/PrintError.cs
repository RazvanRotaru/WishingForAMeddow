using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrintError : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float endTime = 10.0f;

    public TextMeshPro textbox;

    public String text;
    void Start()
    {
        textbox = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != "")
        {
            textbox.text = text;

            startTime += 0.1f;
            if (startTime > endTime)
            {
                startTime = 0.0f;
                text = "";
                textbox.text = "";
            }
        }

    }

    public void Print(String s)
    {
        startTime = 2.0f;
        text = s;
    }
}
