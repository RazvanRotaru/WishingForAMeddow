using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateParams : MonoBehaviour
{
    public Animator anim;
    private Inventory inventory;
    CharacterController charCtrl;
    CharacterInput charIn;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        inventory = GetComponent<Inventory>();
}

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        anim.SetBool("canJump", charCtrl.jumpAnimation);
        anim.SetBool("running", charCtrl.running);
        anim.SetBool("holding", inventory.isFull);
        if (anim.GetBool("jumped"))
        {
            anim.SetBool("jumped", false);
            anim.SetBool("canJump", false);
            charCtrl.jumpAnimation = false;
        }
    }
}
