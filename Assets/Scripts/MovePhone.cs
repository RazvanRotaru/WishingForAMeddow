using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhone : MonoBehaviour
{

    public float sensitivity;
    public GameObject upperLimb;
    public GameObject character;
    public Vector2 mouseLook;
    float max_angles;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        max_angles = character.transform.eulerAngles.y;

        Vector2 look = new Vector2(horizontal, vertical);
        mouseLook = look * sensitivity;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -10f, 20f);
        mouseLook.x = Mathf.Clamp(mouseLook.x, -10f, 10f);

        Quaternion prevRotation = transform.localRotation;
        transform.rotation = Quaternion.AngleAxis(-mouseLook.y, transform.forward) * transform.rotation;

        Quaternion prevUpperRotation = upperLimb.transform.localRotation;
        upperLimb.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up) * upperLimb.transform.localRotation;

        float zAngle = transform.eulerAngles.z;
        bool zModified = false;
        float yAngle = upperLimb.transform.eulerAngles.y;
        bool yModified = false;
        
        if (zAngle < 50)
        {
            zModified = true;
        }
        else if (zAngle > 140)
        {
            zModified = true;
        }
        if (zModified)
            transform.localRotation = prevRotation;
        
        if ((360 + max_angles - yAngle) % 360 > 25 && (360 + max_angles - yAngle) % 360 < 180)
        {
            yModified = true;
        }
        else if ((360 + max_angles - yAngle) % 360 < 345 && (360 + max_angles - yAngle) % 360 >= 180)
        {
            yModified = true;
        }
        if (yModified)
            upperLimb.transform.localRotation = prevUpperRotation;
    }
}
