using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane3 : MonoBehaviour
{
    float vSpeed = 0;
    float hSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 2. 테스트를 위해 일단 주석으로 처리했다.
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = GetComponent<Transform>();

        // 2. 키 입력을 받아 회전을 처리하도록 했다.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vSpeed = -Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed = Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hSpeed = -Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            hSpeed = Time.deltaTime * 10;
        }

        // 3. 키보드에서 손을 땠을 때에는 회전하지 않도록 속도를 0으로 만들었다.
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed = 0;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed = 0;
        }

        tr.Rotate(new Vector3(0, 0, vSpeed));
        tr.Rotate(new Vector3(hSpeed, 0, 0));
    }
}
