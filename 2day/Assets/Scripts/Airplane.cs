using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    float vSpeed = 0;
    float hSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(-1000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = GetComponent<Transform>();
        Rigidbody rb = GetComponent<Rigidbody>();

        float speed = Time.deltaTime * 200;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vSpeed += speed * 0.05f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed -= speed * 0.05f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hSpeed += speed * 0.05f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed -= speed * 0.05f;
        }

        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed *= 0.8f;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed *= 0.8f;
        }

        if (vSpeed > 5)
        {
            vSpeed = 5;
        }

        if (vSpeed < -5)
        {
            vSpeed = -5;
        }

        if (hSpeed > 5)
        {
            hSpeed = 5;
        }

        if (hSpeed < -5)
        {
            hSpeed = -5;
        }

        tr.Rotate(new Vector3(0, 0, -vSpeed));
        tr.Rotate(new Vector3(-hSpeed, 0, 0));

        var localVelocity = tr.InverseTransformDirection(rb.velocity);
        rb.AddRelativeForce(new Vector3(0, -localVelocity.y * speed, 0));

        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(new Vector3(-speed, 0, 0));
        }
    }
}
