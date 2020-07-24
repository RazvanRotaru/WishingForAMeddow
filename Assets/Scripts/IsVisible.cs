using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IsVisible : MonoBehaviour
{
    public bool isVisible;
    public bool held;

    public GameObject visibleObj;
    public Interact script;
    public TextMeshPro textbox;

    // Start is called before the first frame update
    void Start()
    {
        if (visibleObj != null)
            script = visibleObj.GetComponent<PickUp>();
        else
            script = GetComponent<Interact>();
        
        textbox = Camera.main.transform.Find("TextBox").gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        script.isVisible = isVisible;
        if (visibleObj != null)
            held = ((PickUp) script).held;
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
