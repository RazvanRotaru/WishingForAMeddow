using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{

    Vector2 mouseLook;
    public float sensitivity;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        Vector2 look = new Vector2(horizontal, vertical);
        mouseLook += look * sensitivity;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -40, 30);
       // mouseLook.x = Mathf.Clamp(mouseLook.x, -40, 40);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
