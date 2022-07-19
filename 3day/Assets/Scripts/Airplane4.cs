using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane4 : MonoBehaviour
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

        // 4. 부드러운 움직임을 위해서 누적하는 방식을 적용했다!
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vSpeed -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hSpeed -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            hSpeed += Time.deltaTime;
        }

        // 4. 키보드에서 손을 땠을 때에는 천천히 회전하도록 프레임마다 97% 속도로 감속했다.
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed *= 0.97f;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed *= 0.97f;
        }

        tr.Rotate(new Vector3(0, 0, vSpeed));
        tr.Rotate(new Vector3(hSpeed, 0, 0));
    }
}
