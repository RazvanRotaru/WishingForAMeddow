using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeParam : MonoBehaviour
{
    public static GameParameters gp;
    Toggle t;

    // Start is called before the first frame update
    void Start()
    {
        t = this.gameObject.transform.parent.gameObject.GetComponent<Toggle>();
        t.isOn = gp.peaceful;
    }

    // Update is called once per frame
    void Update()
    {
        t.isOn = gp.peaceful;
    }

    public void ChangeMode(bool mode)
    {
        gp.peaceful = mode;
    }
}
