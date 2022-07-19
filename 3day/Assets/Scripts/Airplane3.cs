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
        // 2. �׽�Ʈ�� ���� �ϴ� �ּ����� ó���ߴ�.
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

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

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            hSpeed = Time.deltaTime * 10;
        }

        // 3. Ű���忡�� ���� ���� ������ ȸ������ �ʵ��� �ӵ��� 0���� �������.
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
