using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    float u = 0;
    float d = 0;
    float r = 0;
    float l = 0;

    bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(-1000, 0, 0));
    }

    public void SetDestory(bool destory)
    {
        isDestroyed = destory;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = GameObject.Find("Text");
        GameInfo info = obj.GetComponent<GameInfo>();

        if (collision.gameObject.name == "Terrain")
        {
            info.setCrashed(true);
        }

        if (collision.gameObject.name == "EndLine")
        {
            info.setEnded(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Transform tr = GetComponent<Transform>();

        if (isDestroyed)
        {
            rb.useGravity = true;

            GameObject obj = tr.Find("DestroyFlame").gameObject;
            obj.SetActive(true);

            return;
        }

        float speed = Time.deltaTime * 2;
        float maxSpeed = Time.deltaTime * 200;

        
        var localVelocity = transform.InverseTransformDirection(rb.velocity);

        rb.AddRelativeForce(new Vector3(0, -localVelocity.y * maxSpeed * 2, 0));

        if(Input.GetKey(KeyCode.UpArrow))
        {
            u = Mathf.Lerp(u, -maxSpeed, speed);
            tr.Rotate(new Vector3(0, 0, u));
        }
        else
        {
            u = Mathf.Lerp(u, 0, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            d = Mathf.Lerp(d, maxSpeed * 0.5f, speed * 0.5f);
            tr.Rotate(new Vector3(0, 0, d));
        }
        else
        {
            d = Mathf.Lerp(d, 0, speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            r = Mathf.Lerp(r, maxSpeed, speed);
            tr.Rotate(new Vector3(r, 0, 0));
        }
        else
        {
            r = Mathf.Lerp(r, 0f, speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            l = Mathf.Lerp(l, -maxSpeed, speed);
            tr.Rotate(new Vector3(l, 0, 0));
        }
        else
        {
            l = Mathf.Lerp(l, 0f, speed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(new Vector3(-maxSpeed, 0, 0));
        }
    }
}
