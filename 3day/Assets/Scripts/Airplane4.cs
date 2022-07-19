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
        // 2. �׽�Ʈ�� ���� �ϴ� �ּ����� ó���ߴ�.
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = GetComponent<Transform>();

        // 4. �ε巯�� �������� ���ؼ� �����ϴ� ����� �����ߴ�!
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

        // 4. Ű���忡�� ���� ���� ������ õõ�� ȸ���ϵ��� �����Ӹ��� 97% �ӵ��� �����ߴ�.
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
