using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane6 : MonoBehaviour
{
    float vSpeed = 0;
    float hSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 6. 다시 출발하도록 변경
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = GetComponent<Transform>();

        // 부드러운 움직임을 위해서 누적하는 방식을 적용했다!
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

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed += Time.deltaTime;
        }

        // 키보드에서 손을 땠을 때에는 천천히 회전하도록 프레임마다 97% 속도로 감속했다.
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed *= 0.97f;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed *= 0.97f;
        }

        // 무한정 회전 속도가 늘어나지 않도록 회전 속도에 제한을 넣었다.
        hSpeed = Mathf.Clamp(hSpeed, -Time.deltaTime * 100, Time.deltaTime * 100);
        vSpeed = Mathf.Clamp(vSpeed, -Time.deltaTime * 100, Time.deltaTime * 100);

        tr.Rotate(new Vector3(0, 0, vSpeed));
        tr.Rotate(new Vector3(hSpeed, 0, 0));

        // 6. 비행기 하단에 속도에 비례해서 양력을 받도록 했다.
        Rigidbody rb = GetComponent<Rigidbody>();
        var localVelocity = tr.InverseTransformDirection(rb.velocity);
        rb.AddRelativeForce(new Vector3(0, -localVelocity.y * Time.deltaTime * 500, 0));
    }
}
