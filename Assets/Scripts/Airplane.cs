using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    float u = 0;
    float d = 0;
    float r = 0;
    float l = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(-1000, 0, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            GameObject obj = GameObject.Find("Text");
            GameInfo info = obj.GetComponent<GameInfo>();
            info.setCrashed(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        var localVelocity = transform.InverseTransformDirection(rb.velocity);

        rb.AddRelativeForce(new Vector3(0, -localVelocity.y * 0.6f, 0));

        Transform tr = GetComponent<Transform>();
        if(Input.GetKey(KeyCode.UpArrow))
        {
            u = Mathf.Lerp(u, -0.4f, 0.005f);
            tr.Rotate(new Vector3(0, 0, u));
        }
        else
        {
            u = Mathf.Lerp(u, 0f, 0.01f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            d = Mathf.Lerp(d, 0.4f, 0.005f);
            tr.Rotate(new Vector3(0, 0, d));
        }
        else
        {
            d = Mathf.Lerp(d, 0f, 0.01f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            r = Mathf.Lerp(r, 0.4f, 0.005f);
            tr.Rotate(new Vector3(r, 0, 0));
        }
        else
        {
            r = Mathf.Lerp(r, 0f, 0.01f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            l = Mathf.Lerp(l, -0.4f, 0.005f);
            tr.Rotate(new Vector3(l, 0, 0));
        }
        else
        {
            l = Mathf.Lerp(l, 0f, 0.01f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(new Vector3(-1f, 0, 0));
        }
    }
}
