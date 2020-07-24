using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkForward : MonoBehaviour
{

    public GameObject man;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        man = GameObject.Find("Male_Casual");
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Man_Walk");
    }
}
