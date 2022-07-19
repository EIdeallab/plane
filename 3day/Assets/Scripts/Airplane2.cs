using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 2. �׽�Ʈ�� ���� �ϴ� �ּ����� ó���ߴ�.
        // 1. ���� �� ���
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

    float vSpeed = 0;
    float hSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        Transform tr = GetComponent<Transform>();

        // 2. Ű �Է��� �޾� ȸ���� ó���ϵ��� �ߴ�.
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

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed = Time.deltaTime * 10;
        }

        tr.Rotate(new Vector3(0, 0, vSpeed));
        tr.Rotate(new Vector3(hSpeed, 0, 0));
    }
}
