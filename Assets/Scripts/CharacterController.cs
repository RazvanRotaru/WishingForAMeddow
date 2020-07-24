using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    CharacterInput charIn;
    Rigidbody body;

    public float speed;
    public float jumpforce;
    public Transform groundCheck;

    public bool kinecticPower;
    public bool isGrounded;
    public bool canJump;
    public bool jumpNow;
    public float after_sec;
    public float sec;

    public bool running;
    public bool jumpAnimation;

    void Start()
    {
        charIn = GetComponent<CharacterInput>();
        body = GetComponent<Rigidbody>();
        sec = after_sec;

        EventManager.gainPower += GainPower;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        running = false;
        
        Vector3 moveDir = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;
        
        if (Input.GetKey(charIn.runKey))
        {
            running = true;
            moveDir *= 6;
        }

        transform.Translate(moveDir);


        isGrounded = Physics.CheckSphere(groundCheck.transform.position, 0.1f);

        if(Input.GetKeyDown(charIn.jumpKey) && !jumpAnimation)
        {
            canJump = !canJump;
            jumpAnimation = true;
        }

        if(Input.GetKeyDown(charIn.pauseKey))
        {
            SceneManager.LoadScene("OptionsScene", LoadSceneMode.Additive);
        }

    }

    void FixedUpdate()
    {
        if (canJump)
        {
            sec -= Time.deltaTime * 10;
            if (sec <= 0)
            {
                jumpNow = !jumpNow;
                sec = after_sec;
            }
        }

        if (jumpNow)
        {
            body.AddForce(Vector3.up * jumpforce);
            canJump = !canJump;
            jumpNow = !jumpNow;
        }
    }

    void GainPower()
    {
        kinecticPower = true;
    }
}
